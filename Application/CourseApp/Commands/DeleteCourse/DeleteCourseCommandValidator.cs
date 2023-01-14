using Application.Common.CustomValidators;
using FluentValidation;

namespace Application.CourseApp{
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(p => p.Id).ValidateIntKey();
        }
    }
}
