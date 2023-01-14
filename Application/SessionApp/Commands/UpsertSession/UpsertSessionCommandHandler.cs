using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Entities;

namespace Application.SessionApp
{
    public class UpsertSessionCommandHandler : IRequestHandler<UpsertSessionCommand, bool>
    {
        private readonly IApplicationRepo _repo;

        public UpsertSessionCommandHandler(IApplicationRepo repo)
        {
            _repo = repo;
        }


        public async Task<RespDto<bool>> Handle(UpsertSessionCommand request, CancellationToken cancellationToken)
        {
            Session? classSession;

            var isClassExist = await _repo.ClassRepo.HasAnyWithMessage(p => p.ClassId == request.ClassId);
            if (isClassExist == null || isClassExist.Data == false) return isClassExist;

            if (request.Id != 0)
            {
                var storedSession = await _repo.SessionRepo.FindByIdAsync(request.Id);
                if (storedSession == null || storedSession?.Data == null || storedSession?.Error == true) return storedSession.GetNotFoundError("Session");
                classSession = storedSession?.Data;
                
            }else
            {
                classSession = new Session();
                classSession.ClassId = request.ClassId;
                await _repo.SessionRepo.CreateAsync(classSession);
            }

            classSession.Title = request.Title;
            classSession.StartDate = request.StartDate;
            classSession.EndDate = request.EndDate;
            classSession.Status = request.Status;
            classSession.ActualStartDate = request.ActualStartDate;
            classSession.ActualEndDate = request.ActualEndDate;
           

            await _repo.Commit();
            return new RespDto<bool>() { Data = true };
        }
    }
}
