using FluentValidation;
using VikiCarWash.Application.DTOs;

namespace VikiCarWash.Application.Validators;

public class UpdateBookingValidator : AbstractValidator<UpdateBookingDTO>
{
    public UpdateBookingValidator()
    {

        RuleFor(x => x.CustomerName)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Length(10);

        RuleFor(x => x.CarType)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThan(0);
    }
}