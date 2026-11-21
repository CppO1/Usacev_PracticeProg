using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            var services = new ServiceCollection();

            services.AddDbContext<WorkoutContext>(options =>
                options.UseSqlite("Data Source=workouts.db"));

            // Регистрируем обобщеннный сервис
            services.AddTransient(typeof(Service<>));

            services.AddTransient<Form1>();

            using var serviceProvider = services.BuildServiceProvider();
            var form = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form);
        }
    }
}