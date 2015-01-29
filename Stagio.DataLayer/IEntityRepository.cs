using System.Linq;
using Stagio.Domain.Entities;

namespace Stagio.DataLayer
{
    public  interface IEntityRepository<T> where T : Entity
    {

        IQueryable<T> GetAll(); 
        T GetById(int id);

        void Delete(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}