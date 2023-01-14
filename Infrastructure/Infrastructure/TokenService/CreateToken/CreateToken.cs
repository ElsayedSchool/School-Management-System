﻿using Application.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.InfrastructureService.JWTToken.CreateToken
{
    public class CreateToken: ICreateToken
    {

        public string execute(TokenData tokenData)
        {
            var authClaims = new List<Claim>
            {
                new Claim("Id", tokenData.UserId),
                new Claim("Name", tokenData.Name),
                new Claim("Role", tokenData.Role),
                new Claim(ClaimTypes.Role, tokenData.Role)
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenData.SecurityKey));

            var token = new JwtSecurityToken(

                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
