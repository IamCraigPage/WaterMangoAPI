using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaterMangoAPI.Models;

namespace WaterMangoAPI.Data
{
    public class WaterMangoAPIContext : DbContext
    {
        public WaterMangoAPIContext (DbContextOptions<WaterMangoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WaterMangoAPI.Models.Plants> Plants { get; set; }
    }
}
