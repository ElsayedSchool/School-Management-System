using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryCourseApp
{
    public class UpsertCategoryCourseCommandHandler : IRequestHandler<UpsertCategoryCourseCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertCategoryCourseCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertCategoryCourseCommand request, CancellationToken cancellationToken)
        {
            var courseData = await _repo.CourseRepo.FindByIdAsync(request.CourseId);
            if (courseData == null || courseData.Data == null || courseData.Error == true) return courseData.GetNotFoundError("Course");

            var categoryData = await _repo.CategoryRepo.FindByIdAsync(request.CategoryId);
            if (categoryData == null || categoryData.Data == null || categoryData.Error == true) return categoryData.GetNotFoundError("Grade");

            CategoryCourse? catCourse;
            var isExist = await _repo.CategoryCourseRepo.HasAny(p => p.CategoryId == request.CategoryId && p.CourseId == request.CourseId);
            if (request.Id != 0)
            {
                var catData = await _repo.CategoryCourseRepo.FindByIdAsync(request.Id);
                if (catData == null || catData.Data == null || catData.Error == true) return catData.GetNotFoundError("Grade Course");
                catCourse = catData?.Data;
                if (!isExist)
                {
                    catCourse.CourseId = request.CourseId;
                    catCourse.CategoryId = request.CategoryId;
                }
            }
            else
            {
                
                if(isExist)
                {
                    return new RespDto<bool>().Get400Error("There is a Course Data with the same grade and course");
                }
                catCourse = new CategoryCourse() { CategoryId = request.CategoryId, CourseId = request.CourseId};
                await _repo.CategoryCourseRepo.CreateAsync(catCourse);
            }

            catCourse.CourseDesc = request.CourseDesc;
            catCourse.EnglishDesc = request.EnglishDesc;
            
            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
