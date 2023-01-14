using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;

namespace Application.ClassApp
{
    public class UpsertClassCommandHandler : IRequestHandler<UpsertClassCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertClassCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertClassCommand request, CancellationToken cancellationToken)
        {
            Class? groupClass;
            var isCourseExist = await _repo.CategoryCourseRepo.HasAnyWithMessage(p => p.CategoryCourseId == request.CourseId);
            if (isCourseExist == null || isCourseExist.Data == false) return isCourseExist;

            var isGroupExist = await _repo.GroupRepo.HasAnyWithMessage(p => p.GroupId == request.GroupId);
            if (isGroupExist == null || isGroupExist.Data == false) return isGroupExist;

            var isHallExist = await _repo.HallRepo.HasAnyWithMessage(p => p.HallId == request.HallId);
            if (isHallExist == null || isHallExist.Data == false) return isHallExist;

            var isTeacherExist = await _repo.TeacherRepo.HasAnyWithMessage(p => p.TeacherId == request.TeacherId);
            if (isTeacherExist == null || isTeacherExist.Data == false) return isTeacherExist;

            if (request.Id != 0)
            {
                var storedClass = await _repo.ClassRepo.FindByIdAsync(request.Id);
                if (storedClass == null || storedClass?.Data == null || storedClass?.Error == true) return storedClass.GetNotFoundError("Class");
                groupClass = storedClass?.Data;
                
            }else
            {
                groupClass = new Class();
                await _repo.ClassRepo.CreateAsync(groupClass);
            }

            /*groupClass.ClassName = request.ClassName;
            groupClass.ClassDesc = request.ClassDesc;*/
            groupClass.ClassPrice = request.ClassPrice;
            groupClass.CourseId = request.CourseId;
            groupClass.GroupId = request.GroupId;
            groupClass.HallId = request.HallId;
            groupClass.TeacherId = request.TeacherId;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
