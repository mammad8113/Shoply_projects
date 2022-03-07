using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Domain
{
    public interface IRepository<TKey,T> where T : EntityBase<TKey>
    {
        /// <summary>
        /// create entity
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exist(Expression<Func<T, bool>> expression);
        void Save();
    }
}
