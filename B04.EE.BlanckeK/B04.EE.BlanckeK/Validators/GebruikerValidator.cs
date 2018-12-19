using B04.EE.BlanckeK.Models;
using FluentValidation;
using B04.EE.BlanckeK.Extensions;

namespace B04.EE.BlanckeK.Validators
{
    public class GebruikerValidator : AbstractValidator<Gebruiker>
    {
        
        public GebruikerValidator()
        {
            RuleFor(gebruiker => gebruiker.Naam)
                .NotEmpty()
                .WithMessage("Gelieve een naam in te vullen")
                .Length(3, 30)
                .WithMessage("Gelieve een geldige naam in te vullen")
                .NotNull()
                .WithMessage("Gelieve een geldige naam in te vullen");

            RuleFor(gebruiker => gebruiker.Leeftijd)
                .NotNull()
                .WithMessage("Gelieve een geldige leeftijd in te vullen")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Ik denk dat u een beetje te jong bent om te leren lezen")
                .LessThanOrEqualTo(120)
                .WithMessage("Bent u niet een beetje te oud om nu nog te lezen lezen?");

            RuleFor(gebruiker => gebruiker.Niveau)
                .NotNull()
                .WithMessage("Gelieve een niveau te kiezen");
        }

        
    }
}
