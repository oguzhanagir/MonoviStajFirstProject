using MonoviStajFirstProject.Business.Abstract;
using MonoviStajFirstProject.Business.ValidationRules.FluentValidation;
using MonoviStajFirstProject.Core.Aspects.CacheAspects;
using MonoviStajFirstProject.Core.Aspects.TransactionAspects;
using MonoviStajFirstProject.Core.Aspects.ValidationAspects;
using MonoviStajFirstProject.Core.CrossCuttingConcerns.Caching.MemoryCaches;
using MonoviStajFirstProject.DataAccess.Abstract;
using MonoviStajFirstProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [TransactionScopeAspect]
        [FluentValidateAspect(typeof(UserValidatior))]
        public void Create(User entity)
        {
          
            _unitOfWork.Users.Add(entity);
            _unitOfWork.Save();
        }

        [TransactionScopeAspect]
        public void Delete(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Save();
            }
        }

        [TransactionScopeAspect]
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        [TransactionScopeAspect]
        [CacheAspect(typeof(MemoryCacheManager))]
        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        [TransactionScopeAspect]
        [FluentValidateAspect(typeof(UserValidatior))]
        public void Update(User entity)
        {
            
            _unitOfWork.Users.Update(entity);
            _unitOfWork.Save();
        }



    }
}
