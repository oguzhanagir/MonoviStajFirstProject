using Microsoft.EntityFrameworkCore;
using MonoviStajFirstProject.DataAccess.Abstract;
using MonoviStajFirstProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MonoviStajFirstProjectDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MonoviStajFirstProjectDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }


    }
}
