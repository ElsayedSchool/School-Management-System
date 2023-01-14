using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.StudentGroupApp
{
    public class DeleteStudentGroupCommandValidator : AbstractValidator<DeleteStudentGroupCommand>
    {
        public DeleteStudentGroupCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
