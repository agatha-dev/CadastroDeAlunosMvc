using ProjetoDomain.Mvc.Contracts.Repositories;
using ProjetoDomain.Mvc.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDomain.Mvc.Service
{
    public class BaseDomainService<T> : IBaseDomainService<T>
        where T : class
    {
        public BaseDomainService(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public IBaseRepository<T> baseRepository { get; }

        public virtual void Delete(T obj)
        {
            baseRepository.Delete(obj);
        }

        public List<T> GetAll()
        {
            return baseRepository.GetAll();
        }

        public T GetById(Guid id)
        {
            return baseRepository.GetById(id);
        }

        public virtual void Insert(T obj)
        {
            baseRepository.Insert(obj);
        }

        public virtual void Update(T obj)
        {
            baseRepository.Update(obj);
        }
    }
}
