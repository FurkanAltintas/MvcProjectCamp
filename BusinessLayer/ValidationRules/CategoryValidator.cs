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
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adını boş bırakamazsınız");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız");
            //
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı boş bırakamazsınız");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız");
        }
    }
}
