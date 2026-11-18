using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1.models.Activity
{// Сводка по готовым данным за тренировку
    public class Header
    {
        public int ActivityType { get; set; }
        public string DateTime { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
    }
}