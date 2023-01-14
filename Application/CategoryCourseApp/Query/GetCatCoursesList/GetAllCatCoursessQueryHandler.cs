using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;

namespace Application.CategoryCourseApp
{
    public class GetAllCatCoursesQueryHandler : IRequestHandler<GetAllCatCoursesQuery, List<CatCoursesListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllCatCoursesQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<CatCoursesListVm>>> Handle(GetAllCatCoursesQuery request, CancellationToken cancellationToken)
        {
            var catCourses = await _repo.CategoryCourseRepo.GetAllAsync();
            return _mapper.Map <RespDto<List<CatCoursesListVm>>>(catCourses);
        }
    }
}
