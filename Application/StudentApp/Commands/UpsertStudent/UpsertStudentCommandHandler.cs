using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.StudentApp
{
    public class UpsertStudentCommandHandler : IRequestHandler<UpsertStudentCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertStudentCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student;

            if (request.Id != 0)
            {
                var modifiedStudent = await _repo.StudentRepo.FindByIdAsync(request.Id);
                if (modifiedStudent == null || modifiedStudent?.Data == null || modifiedStudent?.Error == true) return modifiedStudent.GetNotFoundError("This Branch Data is not Exist");
                student = modifiedStudent?.Data;
            }else
            {
                student = new Student();
                await _repo.StudentRepo.CreateAsync(student);
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Phone = request.Phone;
            student.Email = request.Email;

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
