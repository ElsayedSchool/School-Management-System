using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.ProfileApp
{
    public class DeleteProfileCommandValidator : AbstractValidator<DeleteProfileCommand>
    {
        public DeleteProfileCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
