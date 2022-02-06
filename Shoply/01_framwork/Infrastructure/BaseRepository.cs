using _01_framwork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Infrastructure
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T:EntityBase<Tkey>
    {
        private readonly DbContext dbContext;

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
           dbContext.Add<T>(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Any(expression);
        }

        public T Get(Tkey id)
        {
            return dbContext.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
