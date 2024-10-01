using DEPI_Propject_Company_System.Data;
using DEPI_Propject_Company_System.Repositoories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DEPI_Propject_Company_System.Repositoories
{
    public class CRUD<T> : ICRUD<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CRUD(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            if (entity is null) 
                return;
            _dbSet.Add(entity);
            Save();
        }

        public bool Delete(int id)
        {
            var modelFromDb = _dbSet.Find(id);
            if (modelFromDb is null) 
                return false;
            _dbSet.Remove(modelFromDb);
            Save();
            return true;
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id) ?? throw new ArgumentNullException(nameof(id), "Not found.");
        }

        public bool Update(int id, T entity)
        {
            var modelFromDb = _dbSet.Find(id);
            if (entity is null || modelFromDb is null)
                return false;

            _context.Entry(modelFromDb).CurrentValues.SetValues(entity);
            Save();
            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
