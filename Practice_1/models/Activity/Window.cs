using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Practice_1.models.Activity
{
    //отчет по кругам
    public class Window
    {
        public double Distance { get; set; }
        public double Duration { get; set; }
        public List<SpeedData> Speed { get; set; } 
        public string Type { get; set; }
    }
    // отчет по скорости
    public class SpeedData
    {
        public double? Avg { get; set; }
        public double? Max { get; set; }
        public double? Min { get; set; }
    }
}