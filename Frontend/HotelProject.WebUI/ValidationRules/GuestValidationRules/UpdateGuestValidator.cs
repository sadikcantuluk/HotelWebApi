using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş geçilemez.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Boş geçilemez.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Boş geçilemez.");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakterli giriş yapmalısınız.");
            RuleFor(x => x.SurName).MinimumLength(3).WithMessage("En az 3 karakterli giriş yapmalısınız.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Boş geçilemez.");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla 20 karakterli giriş yapabilirsiniz.");
            RuleFor(x => x.SurName).MaximumLength(20).WithMessage("En fazla 20 karakterli giriş yapabilirsiniz.");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("En fazla 20 karakterli giriş yapabilirsiniz.");
        }
    }
}
