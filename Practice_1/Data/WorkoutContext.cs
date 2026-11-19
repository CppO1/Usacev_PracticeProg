using Microsoft.EntityFrameworkCore;
using Practice_OOP.models;

namespace Practice_OOP.Data
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutLap> WorkoutLaps { get; set; }

        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
        {
            // ЭТА СТРОКА СОЗДАСТ ТАБЛИЦЫ ПРИ ПЕРВОМ ЗАПУСКЕ
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=workouts.db");
            }
        }
    }
}