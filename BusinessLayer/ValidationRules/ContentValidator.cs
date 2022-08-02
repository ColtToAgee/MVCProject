using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContentValidator:AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(x=>x.ContentValue).NotEmpty().WithMessage("Lütfen İçerik Alanını Boş Bırakmayınız!!!");
            RuleFor(x => x.WriterId).NotEmpty().WithMessage("Lütfen Yazar Alanını Boş Bırakmayınız");
            RuleFor(x => x.HeadingId).NotEmpty().WithMessage("Lütfen Başlık Alanını Boş Bırakmayınız");
            RuleFor(x => x.ContentValue).MinimumLength(3).WithMessage("Lütfen 3 Karakterden Fazla Değer Giriniz!!!");
        }
    }
}
