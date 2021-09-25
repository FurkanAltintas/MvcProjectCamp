using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adını boş bırakamazsınız");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız");
            //
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Yazar soyadını boş bırakamazsınız");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkımda kısmını boş bırakamazsınız");

            //Ödev
            //RuleFor(x => x.About).Must(x => x.ToUpper().Contains("A"))
            //    .WithMessage("Hakkımda kısmında a harfi zorunludur");
        }
    }
}
