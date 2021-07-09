using Microsoft.EntityFrameworkCore;
using Tp.Restaurante.Domain.Commands;

namespace Tp.Restaurante.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository 
    {
        private readonly RestauranteDbContext _context;
        public GenericsRepository (RestauranteDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public T Exists<T>(int id) where T : class
        {
           var x = _context.Find<T>(id);
            return x;
        }
    }
}
