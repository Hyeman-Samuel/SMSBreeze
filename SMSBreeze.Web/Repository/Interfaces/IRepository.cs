using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Repository.Interfaces
{
   public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Edit(T entity);

        void Delete(T entity);

        IList<T> GetAll();

        IList<T> GetWith(Func<T, bool> predicate);

        T GetById(int Id);

        int Count(Func<T, bool> predicate);
    }
}
