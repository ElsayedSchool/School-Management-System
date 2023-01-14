using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Application.ProfileApp;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TeacherApp
{
    public class UpsertTeacherCommandHandler : IRequestHandler<UpsertTeacherCommand, bool>
    {
        private readonly IApplicationRepo _repo;
        private readonly MediatR.IMediator _mediator;
        private readonly IMapper _mapper;

        public UpsertTeacherCommandHandler(IApplicationRepo repo, MediatR.IMediator mediator, IMapper mapper)
        {
            _repo = repo;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<RespDto<bool>> Handle(UpsertTeacherCommand request, CancellationToken cancellationToken)
        {
            var userProfile = _mapper.Map<UpsertProfileCommand>(request);
            var profileResp = await _mediator.Send(userProfile);
            if (profileResp == null || profileResp.Error || profileResp.Data == 0) return new RespDto<bool>().Get500Error(profileResp.Message);
            
            var teacherResp = await _repo.TeacherRepo.HasAny( p => p.TeacherId == request.Id);
            Teacher? teacher;
            if (teacherResp)
            {
                var branchTeacher = await _repo.TeacherRepo.FindByIdAsync(request.Id);
                teacher = branchTeacher?.Data;
                teacher.TeacherId = request.Id;
            }
            else
            {
                teacher = new Teacher();
                teacher.TeacherId = profileResp.Data;
                await _repo.TeacherRepo.CreateAsync(teacher);
            }

            teacher.YearsOfExperience = request.YearsOfExperience;
            teacher.CourseId = request.CourseId;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
