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

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Length(10).WithMessage("Phone number must be 10 digits");

        RuleFor(x => x.CarType)
            .NotEmpty().WithMessage("Car type is required");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.BookingDate)
            .GreaterThan(DateTime.Now.AddDays(-1))
            .WithMessage("Booking date must be today or future");
    }
}