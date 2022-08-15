using FluentValidation;
using FluentValidationMit.NetCore6.Web.Models;

namespace FluentValidationMit.NetCore6.Web.FluentValidierer
{
    public class KundeValidierer:AbstractValidator<Kunde>
    {
        public string NichtLeereNachricht { get; } = "{PropertyName}sfeld darf nicht leer sein";
        public KundeValidierer()
        {
            //Die serverseitige Validierung wird von KundeValidator durchgeführt.

            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName}nsfeld darf nicht leer sein");
            RuleFor(x => x.Email).NotEmpty().WithMessage(NichtLeereNachricht)
                .EmailAddress().WithMessage("Die E-Mail hat nicht das richtige Format");
            RuleFor(x => x.Alter).NotEmpty().WithMessage(NichtLeereNachricht)
                .InclusiveBetween(18, 60).WithMessage("Altersfeld muss zwischen 18 und 60 sein");
            RuleFor(x => x.GeburtsDatum).NotEmpty().WithMessage(NichtLeereNachricht).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Sie müssen über 18 Jahre alt sein, um auf diese Website zugreifen zu können");

            RuleForEach(x => x.Adressen).SetValidator(new AdresseValidator());
            //Bei KundeController in Create Methode könnte man so schreiben

            //AdresseValidator adresseValidator = new AdresseValidator();
            //kunde.Adresse.ToList().ForEach(XmlConfigurationExtensions =>
            //{
            //    adresseValidator.Validate(x);
            //});

        }
    }
}
