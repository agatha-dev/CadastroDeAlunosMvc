using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDomain.Mvc.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> GetAll();
        T GetById(Guid id);
    }
}
