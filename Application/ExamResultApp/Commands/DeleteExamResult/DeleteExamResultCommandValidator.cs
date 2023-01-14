using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.ExamResultApp
{
    public class DeleteExamResultCommandValidator : AbstractValidator<DeleteExamResultCommand>
    {
        public DeleteExamResultCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
