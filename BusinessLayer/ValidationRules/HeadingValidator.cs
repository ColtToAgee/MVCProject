using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adını Boş Bırakmayın!!!");
            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Tarihi Boş Bırakmayın!!!");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın!!!");
        }
    }
}
