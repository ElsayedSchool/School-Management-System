using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HallApp{
    public class UpsertHallCommandHandler : IRequestHandler<UpsertHallCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertHallCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertHallCommand request, CancellationToken cancellationToken)
        {
            Hall? hall ;
            var isBranchExist = await _repo.BranchRepo.HasAnyWithMessage(p => p.BranchId == request.BranchId);
            if (isBranchExist == null || isBranchExist.Data == false) return isBranchExist;
            if(request.Id != 0)
            {
                var branchHall = await _repo.HallRepo.FindByIdAsync(request.Id);
                if (branchHall == null || branchHall?.Data == null || branchHall?.Error == true) return branchHall.GetNotFoundError("This Branch Data is not Exist");
                hall = branchHall?.Data;
            }else
            {
                hall = new Hall();
                await _repo.HallRepo.CreateAsync(hall);
            }

            hall.HallName = request.HallName;
            hall.IsConditioned = request.IsConditioned;
            hall.MaxStudents = request.MaxStudents;
            hall.PricePerStudent = request.PricePerStudent;
            hall.PricePerHour = request.PricePerHour;
            hall.MinReservationTime = request.MinReservationTime;
            hall.HourEquivalentTime = request.HourEquivalentTime;
            hall.BranchId = request.BranchId;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
