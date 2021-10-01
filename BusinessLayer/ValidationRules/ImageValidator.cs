using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator :AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adı boş bırakamazsınız");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Görseli boş bırakamazsınız");
            RuleFor(x => x.ImageCategoryId).NotEmpty().WithMessage("Kategoriyi boş bırakamazsınız");

            RuleFor(x => x.Name).MaximumLength(150).WithMessage("Lütfen 150 karakterden fazla değer girişi yapmayınız");
        }
    }
}
