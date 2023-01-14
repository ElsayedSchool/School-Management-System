using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.StudentAbsenceApp
{
    public class DeleteStudentAbsenceCommandValidator : AbstractValidator<DeleteStudentAbsenceCommand>
    {
        public DeleteStudentAbsenceCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
