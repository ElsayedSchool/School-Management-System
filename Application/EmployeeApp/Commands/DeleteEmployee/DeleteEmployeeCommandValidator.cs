using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.EmployeeApp
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
