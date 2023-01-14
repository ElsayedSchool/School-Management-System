using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassApp
{
    public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, List<ClassesListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllClassesQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<ClassesListVm>>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
        {
            var groups = await _repo.ClassRepo.GetAllClassesAsync();
            return _mapper.Map<RespDto<List<ClassesListVm>>>(groups);
        }
    }
}
