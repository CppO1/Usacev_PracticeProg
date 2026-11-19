using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_OOP.models.Activity
{//Информация для преобразования в данные
    public class Sample
    {
        public double? Distance { get; set; }
        public double? Speed { get; set; }
        public string TimeISO8601 { get; set; } 
        public Event[] Events { get; set; }
    }

    public class Event
    {
        public Lap Lap { get; set; }
    }

    public class Lap
    {
        public string Type { get; set; } 
    }
}