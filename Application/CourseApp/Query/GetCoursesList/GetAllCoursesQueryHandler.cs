using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseApp
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, CoursesListVm>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllCoursesQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<CoursesListVm>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {

            var Courses = await _repo.CourseRepo.GetAllAsync();
            if (Courses.HasError()) return new RespDto<CoursesListVm>().Get500Error(Courses.Message);
            var CoursesDtos = _mapper.Map<IEnumerable<CourseDto>>(Courses.Data);
            var coursesList = new CoursesListVm() { Courses = CoursesDtos.ToList() };
            return new RespDto<CoursesListVm>() { Data = coursesList};
        }
    }
}
