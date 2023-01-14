using Application.Common.Interfaces;
using Application.Common.Mediatr;
using Application.Common.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, bool>
    {
        private readonly IUserManagerService _userManager;

        public SignUpCommandHandler(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public async Task<RespDto<bool>> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var isCreated = await _userManager.CreateUserAsync(request.Email,request.Password, request.Name);
            if(isCreated == null || isCreated.Error == true)
            {
                return isCreated;
            }
            var user = await _userManager.GetUserByNameAsync(request.Email);
            var updatedUser = await _userManager.AddUserToRoleAsync(user, AppRoles.Student);
            return updatedUser;
        }
    }
}
