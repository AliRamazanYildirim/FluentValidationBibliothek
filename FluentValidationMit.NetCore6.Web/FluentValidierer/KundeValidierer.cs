using FluentValidation;
using FluentValidationMit.NetCore6.Web.Models;

namespace FluentValidationMit.NetCore6.Web.FluentValidierer
{
    public class KundeValidierer:AbstractValidator<Kunde>
    {
        public string NoEmptyMessage { get; } = "{PropertyName}sfeld darf nicht leer sein";
        public KundeValidierer()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NoEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NoEmptyMessage)
                .EmailAddress().WithMessage("Die E-Mail hat nicht das richtige Format");
            RuleFor(x => x.Alter).NotEmpty().WithMessage(NoEmptyMessage)
                .InclusiveBetween(18, 60).WithMessage("Altersfeld muss zwischen 18 und 60 sein");
            RuleFor(x => x.GeburtsDatum).NotEmpty().WithMessage(NoEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Sie müssen über 18 Jahre alt sein, um auf diese Website zugreifen zu können");

        }
    }
}
