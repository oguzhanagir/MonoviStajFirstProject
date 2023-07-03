using FluentValidation;
using MonoviStajFirstProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoviStajFirstProject.Business.ValidationRules.FluentValidation
{
    public class UserValidatior : AbstractValidator<User>
    {
        public UserValidatior()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("Adınız Boş Olamaz!").Length(0, 50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Soyadınız Boş Olamaz!").Length(0, 50);
            RuleFor(x => x.Mail).NotNull().NotEmpty().WithMessage("Soyadınız Boş Olamaz!").Length(0, 50);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("Telefon Numaranız Boş Olamaz!").Length(0, 15);
        }
    }
}
