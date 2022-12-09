using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Bırakmayın!!!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Bırakmayın!!!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Kısmını Boş Bırakmayın!!!");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın!!!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapın!!!");
            RuleFor(x => x.WriterAbout).Must((x, t) => x.WriterAbout.Contains('a')).WithMessage("Lütfen Hakkında Kısmının İçerisine 'a' Karakteri Giriniz!!!");
        }
    }
}
