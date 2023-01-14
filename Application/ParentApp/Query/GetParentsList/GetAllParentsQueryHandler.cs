using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParentApp
{
    public class GetAllParentsQueryHandler : IRequestHandler<GetAllParentsQuery, List<ParentsListVm>>
    {
        private readonly IApplicationRepo _repo;
        private readonly IMapper _mapper;

        public GetAllParentsQueryHandler(IApplicationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<RespDto<List<ParentsListVm>>> Handle(GetAllParentsQuery request, CancellationToken cancellationToken)
        {
           
            var students = await _repo.ParentRepo.GetAllAsync();
            return _mapper.Map<RespDto<List<ParentsListVm>>>(students);
        }
    }
}
