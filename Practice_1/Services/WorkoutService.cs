using Microsoft.EntityFrameworkCore;
using Practice_OOP.Data;
using Practice_OOP.models;
using System.Collections.Generic;
using System.Linq;

namespace Practice_OOP.Services
{
    public class WorkoutService
    {
        private readonly WorkoutContext _context;

        public WorkoutService(WorkoutContext context)
        {
            _context = context;
        }

        // Получить все сохраненные тренировки
        public List<Workout> GetAllWorkouts()
        {
            return _context.Workouts.ToList();
        }

        // Получить тренировку с её кругами по ID
        public Workout GetWorkoutById(int id)
        {
            return _context.Workouts
                .Include(w => w.Laps)
                .FirstOrDefault(w => w.Id == id);
        }

        // Сохранить тренировку
        public void AddWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
            _context.SaveChanges();
        }
    }
}