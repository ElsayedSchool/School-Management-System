using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.HallApp{
    public class DeleteHallCommandValidator : AbstractValidator<DeleteHallCommand>
    {
        public DeleteHallCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
