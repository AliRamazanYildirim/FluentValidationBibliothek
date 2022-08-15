using FluentValidation;
using FluentValidationMit.NetCore6.Web.Models;

namespace FluentValidationMit.NetCore6.Web.FluentValidierer
{
    public class AdresseValidator:AbstractValidator<Adresse>
    {
        public string NichtLeereNachricht { get; } = "{PropertyName}sfeld darf nicht leer sein";
        public AdresseValidator()
        {
            RuleFor(x => x.Inhalt).NotEmpty().WithMessage(NichtLeereNachricht);
            RuleFor(x => x.Provinz).NotEmpty().WithMessage(NichtLeereNachricht);
            RuleFor(x => x.PostleitZahl).NotEmpty().WithMessage(NichtLeereNachricht).
                MaximumLength(5).WithMessage("{PropertyName}sfeld kann maximal {MaxLength} sein");

        }
    }
}
