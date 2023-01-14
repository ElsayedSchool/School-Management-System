using Application.Common.Models;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.SInfrastructure.Identity
{
    public static class IdentityResultExtension
    {
        public static RespDto<bool> ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? new RespDto<bool>() { Data = true }
                : new RespDto<bool>() { Data = false, Error = true, Message = String.Concat(result.Errors.Select(e => e.Description)) };
        }  
        
    }
}
