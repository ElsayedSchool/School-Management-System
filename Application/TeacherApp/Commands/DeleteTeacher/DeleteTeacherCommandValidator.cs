using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.TeacherApp
{
    public class DeleteTeacherCommandValidator : AbstractValidator<DeleteTeacherCommand>
    {
        public DeleteTeacherCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
