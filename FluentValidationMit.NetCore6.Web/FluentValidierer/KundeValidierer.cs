using FluentValidation;
using FluentValidationMit.NetCore6.Web.Models;

namespace FluentValidationMit.NetCore6.Web.FluentValidierer
{
    public class KundeValidierer:AbstractValidator<Kunde>
    {
        public KundeValidierer()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Namensfeld darf nicht leer sein");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Emailfeld darf nicht leer sein")
                .EmailAddress().WithMessage("Die E-Mail hat nicht das richtige Format");
            RuleFor(x => x.Alter).NotEmpty().WithMessage("Altersfeld darf nicht leer sein")
                .InclusiveBetween(18, 60).WithMessage("Altersfeld muss zwischen 18 und 60 sein");

        }
    }
}
