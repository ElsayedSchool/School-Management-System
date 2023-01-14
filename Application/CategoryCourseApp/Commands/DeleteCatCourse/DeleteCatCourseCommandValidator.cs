using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.CategoryCourseApp
{
    public class DeleteCategoryCourseCommandValidator : AbstractValidator<DeleteCategoryCourseCommand>
    {
        public DeleteCategoryCourseCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
