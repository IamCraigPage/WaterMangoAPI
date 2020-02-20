using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterMangoAPI.Models
{
    public class Plants
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime? lastWatered { get; set; }
    }
}
