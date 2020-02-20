using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaterMangoAPI.Data;
using WaterMangoAPI.Models;

namespace WaterMangoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterPlantController : ControllerBase
    {
        private readonly WaterMangoAPIContext _context;

        public WaterPlantController(WaterMangoAPIContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> WaterPlant(int id)
        {
            var plants = await _context.Plants.FindAsync(id);

            if (plants == null)
            {
                return NotFound();
            }

            System.DateTime finishTime = System.DateTime.Now.AddSeconds(10);
            plants.lastWatered = finishTime;//"2020-01-25 01:11:59"; // YYYY-MM-DD hh:mm:ss
                                            //            plants.name = "Plant 3";

            _context.Entry(plants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool PlantsExists(int id)
        {
            return _context.Plants.Any(e => e.id == id);
        }
    }
}
