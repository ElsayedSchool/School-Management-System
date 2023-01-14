using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication{
    public class TokenData
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string SecurityKey { get; set; }

        public TokenData GetTokenData(ApplicationUser user, string role, string securityKey)
        {
            return new TokenData() { Name = user.UserName, Role = role, UserId = user.Id, SecurityKey = securityKey };
        }
    }
}
