using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseApp{
    public class UpsertCourseCommandHandler : IRequestHandler<UpsertCourseCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertCourseCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertCourseCommand request, CancellationToken cancellationToken)
        {
            Course? Course;
            if(request.Id != 0)
            {
                var storedCourse = await _repo.CourseRepo.FindByIdAsync(request.Id);
                if (storedCourse == null || storedCourse?.Data == null || storedCourse?.Error == true) return storedCourse.GetNotFoundError("Course");
                Course = storedCourse?.Data;
            }else
            {
                Course = new Course();
                await _repo.CourseRepo.CreateAsync(Course);
            }

            Course.CourseName = request.CourseName;
            Course.EnglishName = request.EnglishName;

            await _repo.Commit();

            return new RespDto<bool>() { Data = true };
        }
    }
}
