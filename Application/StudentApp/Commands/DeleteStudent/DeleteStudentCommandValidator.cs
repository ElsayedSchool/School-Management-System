using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.StudentApp
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
