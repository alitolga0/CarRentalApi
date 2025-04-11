using CarRentalApi.Models;
using FluentValidation;

namespace CarRentalApi.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            //RuleFor(x => x.FirstName)
            //    .NotEmpty().WithMessage("İsim zorunludur.")
            //    .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir.");

            //RuleFor(x => x.LastName)
            //    .NotEmpty().WithMessage("Soyisim zorunludur.")
            //    .MaximumLength(50).WithMessage("Soyisim en fazla 50 karakter olabilir.");

        }
    }
}
