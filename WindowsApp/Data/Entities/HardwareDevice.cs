using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsHunter.Data.Entities {
    public class HardwareDevice {
        public int Id { get; set; } // Primary Key
        public  string? IP { get; set; }
        public int blinky_ms { get; set; }
        public int brightness { get; set; }
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
    }
}