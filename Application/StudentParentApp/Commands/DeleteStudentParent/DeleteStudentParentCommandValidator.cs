using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.StudentParentApp
{
    public class DeleteStudentParentCommandValidator : AbstractValidator<DeleteStudentParentCommand>
    {
        public DeleteStudentParentCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
