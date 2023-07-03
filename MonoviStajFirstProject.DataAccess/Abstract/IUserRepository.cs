﻿using MonoviStajFirstProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
