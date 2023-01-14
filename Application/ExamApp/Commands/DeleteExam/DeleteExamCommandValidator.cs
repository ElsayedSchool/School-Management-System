using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.ExamApp
{
    public class DeleteExamCommandValidator : AbstractValidator<DeleteExamCommand>
    {
        public DeleteExamCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
