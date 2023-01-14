using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUserManagerService
    {
        Task<RespDto<bool>> CreateUserAsync(string userName, string password, string Name);
        Task<RespDto<bool>> DeleteUserAsync(string userId);
        Task<ApplicationUser> GetUserById(string Id);
        Task<ApplicationUser> GetUserByNameAsync(string username);
        Task<IList<string>> GetUserRoleAsync(ApplicationUser user);
        Task<RespDto<bool>> GetUserRoleAsync(ApplicationUser user, string role);
        Task<RespDto<bool>> isPasswordValid(ApplicationUser signInUser, string password);
        Task<RespDto<bool>> ChangeUserPassword(ApplicationUser signInUser, string oldPassword, string newPassword);
        Task<RespDto<bool>> AddUserToRoleAsync(ApplicationUser user, string role);
        Task<RespDto<bool>> HasAny();

    }
}
