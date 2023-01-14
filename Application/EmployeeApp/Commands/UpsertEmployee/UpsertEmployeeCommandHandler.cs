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

namespace Application.EmployeeApp
{
    public class UpsertEmployeeCommandHandler : IRequestHandler<UpsertEmployeeCommand, bool>
    {
        private readonly IApplicationRepo _repo;
        private readonly MediatR.IMediator _mediator;
        private readonly IMapper _mapper;

        public UpsertEmployeeCommandHandler(IApplicationRepo repo, MediatR.IMediator mediator, IMapper mapper)
        {
            _repo = repo;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<RespDto<bool>> Handle(UpsertEmployeeCommand request, CancellationToken cancellationToken)
        {
            var userProfile = _mapper.Map<UpsertProfileCommand>(request);
            var profileResp = await _mediator.Send(userProfile);
            if (profileResp == null || profileResp.Error || profileResp.Data == 0) return new RespDto<bool>().Get500Error(profileResp.Message);

            Employee? employee;
            var isBranchExist = await _repo.BranchRepo.HasAnyWithMessage(p => p.BranchId == request.BranchId);
            if (isBranchExist == null || isBranchExist.Data == false) return isBranchExist;

            if (request.Id != 0)
            {
                var branchEmployee = await _repo.EmployeeRepo.FindByIdAsync(request.Id);
                if (branchEmployee == null || branchEmployee?.Data == null || branchEmployee?.Error == true) return branchEmployee.GetNotFoundError("Employee");
                employee = branchEmployee?.Data;
                employee.EmployeeId = request.Id;
            }else
            {
                employee = new Employee();
                await _repo.EmployeeRepo.CreateAsync(employee);
                employee.EmployeeId = profileResp.Data;
            }

            employee.WorkStartTime = request.WorkStartTime;
            employee.WorkEndTime = request.WorkEndTime;
            employee.AbsenceBalance = request.AbsenceBalance;
            employee.BranchId = request.BranchId;
            employee.Salary = request.Salary;
           
            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
