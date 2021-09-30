using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {

            //string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            //                           + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            //                           + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            //Ödev

            //RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta gerekli");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını adını boş bırakamazsınız");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adını boş bırakamazsınız");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parolayı boş bırakamazsınız");
        }
    }
}
