using System.Collections.Generic;

namespace Practice_OOP.models
{
    public class Workout
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Time { get; set; }
        public double Distance { get; set; }

        // Связь с таблицей кругов
        public List<WorkoutLap> Laps { get; set; } = new List<WorkoutLap>();
    }
}