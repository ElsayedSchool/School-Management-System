using Application.Common.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HallApp{
    public class UpsertHallCommandValidator: AbstractValidator<UpsertHallCommand>
    {
        public UpsertHallCommandValidator()
        {
            RuleFor(p => p.HallName).ValidateName();

            RuleFor(p => p.IsConditioned);

            RuleFor(p => p.MaxStudents).ValidateGreaterThan();

            RuleFor(p => p.PricePerHour)
                .GreaterThan(0).WithMessage("please enter price per hour for hall");

            RuleFor(p => p.PricePerStudent)
                .GreaterThan(0).WithMessage("please enter price per student for hall");

            RuleFor(p => p.MinReservationTime)
                .GreaterThanOrEqualTo(0).WithMessage("please enter minmum reservation time for hall");

            RuleFor(p => p.HourEquivalentTime)
                .Must(p => p > 0 && p < 60).WithMessage($"Hour Equivalent Time should be between 0 and 60 minute");

            RuleFor(p => p.BranchId).ValidateIntKey();
        }
    }
}
