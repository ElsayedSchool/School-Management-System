using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Infrastructure.SInfrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Infrastructure.Identity
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<RespDto<bool>> CreateUserAsync(string userName, string password, string Name)
        {

            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return result.ToApplicationResult();
        }


        public async Task<ApplicationUser> GetUserById(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }


        public async Task<ApplicationUser> GetUserByNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }


        public async Task<IList<string>> GetUserRoleAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }


        public async Task<RespDto<bool>> GetUserRoleAsync(ApplicationUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            return result.ToApplicationResult();
        }


        public async Task<RespDto<bool>> isPasswordValid(ApplicationUser signInUser, string password)
        {
            var user = await _userManager.CheckPasswordAsync(signInUser, password);
            if (user == false)
            {
                return new RespDto<bool>() { Error = true, Message = "username or Password is incorrect" };
            }
            return new RespDto<bool>() { Data = true };
        }


        public async Task<RespDto<bool>> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                //return await DeleteUserAsync(user);
            }

            return new RespDto<bool>() { Data = true };
        }

        public async Task<RespDto<bool>> ChangeUserPassword(ApplicationUser signInUser, string oldPassword, string newPassword)
        {
            var changePasswordStatus = await _userManager.ChangePasswordAsync(signInUser, oldPassword, newPassword);
            return changePasswordStatus.ToApplicationResult();
        }

        public async Task<RespDto<bool>> AddUserToRoleAsync(ApplicationUser user, string role)
        {
           var updatedUser = await _userManager.AddToRoleAsync(user, role);
            return updatedUser.ToApplicationResult();
        }

        public async Task<RespDto<bool>> HasAny()
        {
            var isExist = _userManager.Users.Any();
            return new RespDto<bool>() { Data= isExist };
        }
    }
}
