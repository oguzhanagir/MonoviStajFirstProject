using MonoviStajFirstProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MonoviStajFirstProjectDbContext _dbContext;

        public UnitOfWork(MonoviStajFirstProjectDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = new UserRepository(_dbContext);
        }

        public IUserRepository Users { get; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
