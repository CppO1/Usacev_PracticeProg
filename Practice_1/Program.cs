using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice_OOP;
using Practice_OOP.Data;
using Practice_OOP.Services;
using System;
using System.Windows.Forms;

namespace Practice_OOP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Создаем контейнер зависимостей
            var services = new ServiceCollection();

            // 1. Регистрируем контекст базы данных SQLite
            services.AddDbContext<WorkoutContext>(options =>
                options.UseSqlite("Data Source=workouts.db"));

            // 2. Регистрируем сервис
            services.AddTransient<WorkoutService>();

            // 3. Регистрируем форму
            services.AddTransient<Form1>();

            // Запускаем приложение, доставая форму из контейнера
            using var serviceProvider = services.BuildServiceProvider();
            var form = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form);
        }
    }
}