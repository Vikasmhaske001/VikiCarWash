using FluentValidation;
using VikiCarWash.Application.DTOs;

namespace VikiCarWash.Application.Validators;

public class CreateBookingValidator : AbstractValidator<CreateBookingDTO>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Customer name is required")
            .MaximumLength(50);

        RuleFor(x => x.CarType)
            .NotEmpty().WithMessage("Car type is required");

        RuleFor(x => x.WashType)
            .NotEmpty().WithMessage("Wash type is required");

        RuleFor(x => x.BookingDate)
            .GreaterThan(DateTime.Now.AddDays(-1))
            .WithMessage("Booking date must be today or future");
    }
}