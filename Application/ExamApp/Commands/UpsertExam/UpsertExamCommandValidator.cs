using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamApp
{
    public class UpsertExamCommandValidator : AbstractValidator<UpsertExamCommand>
    {
        public UpsertExamCommandValidator()
        {
            RuleFor(p => p.Id);

            RuleFor(p => p.SessionId);
                
            RuleFor(p => p.ClassId).ValidateIntKey();

            RuleFor(p => p.OverView).ValidateDescription();

            RuleFor(p => p.TotalDegree).ValidateGreaterThan(-1);

        }
    }
}
