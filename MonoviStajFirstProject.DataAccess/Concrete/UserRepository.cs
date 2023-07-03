using MonoviStajFirstProject.DataAccess.Abstract;
using MonoviStajFirstProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MonoviStajFirstProjectDbContext dbContext): base(dbContext)
        {
            
        }
    }
}
