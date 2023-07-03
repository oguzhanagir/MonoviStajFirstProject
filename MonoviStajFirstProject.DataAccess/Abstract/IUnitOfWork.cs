using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.DataAccess.Abstract
{
    public interface IUnitOfWork 
    {
        IUserRepository Users { get; }


        void Save();
    }
}
