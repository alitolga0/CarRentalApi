﻿using CarRentalApi.Models;
using FluentValidation;

namespace CarRentalApi.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.LicensePlate)
                .NotEmpty().WithMessage("Plaka zorunludur")
                .EmailAddress().WithMessage("Geçerli bir plaka giriniz.");
        }
    }
}
