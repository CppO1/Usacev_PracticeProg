namespace Practice_OOP.models
{
    public class WorkoutLap
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public double AverageSpeed { get; set; }

        // Внешний ключ на тренировку
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}