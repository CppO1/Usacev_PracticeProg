using Microsoft.EntityFrameworkCore;
using Practice_OOP.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_OOP.Services
{
    //  class означает, что T должен быть классом (сущностью БД)
    public class Service<T> where T : class
    {
        private readonly WorkoutContext _context;

        public Service(WorkoutContext context)
        {
            _context = context;
        }

        // 1. Получить все объекты типа T
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        // 2. Получить объект по ID
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        // 3. Добавить объект
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        // 4. Фильтр с помощью делегата Predicate<T>
        public List<T> Get(Predicate<T> predicate)
        {
            // Сначала выгружаем все в память, затем фильтруем через FindAll
            return _context.Set<T>().ToList().FindAll(predicate);
        }
    }
}