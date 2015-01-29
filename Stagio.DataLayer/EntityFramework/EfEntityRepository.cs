using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Validation;
using Stagio.Domain.Entities;
using System.Diagnostics;

namespace Stagio.DataLayer.EntityFramework
{
    public class EfEntityRepository<T>: IEntityRepository<T> where T : Entity
    {
        private readonly DbContext _context;

        public EfEntityRepository()
        {
            _context = new StagioDbContext();
        }
        
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Add(T entity)
        {
            try
            {

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.Print("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.Print("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
     
    }

}


