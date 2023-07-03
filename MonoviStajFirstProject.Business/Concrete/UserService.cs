using MonoviStajFirstProject.Business.Abstract;
using MonoviStajFirstProject.Business.ValidationRules.FluentValidation;
using MonoviStajFirstProject.Core.CrossCuttingConcerns.Validation.FluentValidation;
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

   
        public void Create(User entity)
        {
            ValidatorTool.FluentValidate(new UserValidatior(),entity);
            _unitOfWork.Users.Add(entity);
            _unitOfWork.Save();
        }


        public void Delete(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }
        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }


      
        public void Update(User entity)
        {
            ValidatorTool.FluentValidate(new UserValidatior(), entity);
            _unitOfWork.Users.Update(entity);
            _unitOfWork.Save();
        }



    }
}
