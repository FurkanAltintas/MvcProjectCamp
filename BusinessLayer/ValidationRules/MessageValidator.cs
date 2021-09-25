using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            //string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            //                           + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            //                           + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini adını boş bırakamazsınız");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş bırakamazsınız");
            RuleFor(x => x.Messages).NotEmpty().WithMessage("Mesajı boş bırakamazsınız");
            //
            RuleFor(x => x.ReceiverMail).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Messages).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            //
            RuleFor(x => x.ReceiverMail).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız");

            //Ödev
            //RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir e-posta gerekli");
        }
    }
}
