using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GymT.Common.View.Account;
using Microsoft.IdentityModel.Tokens;

namespace GymT.Common.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string GenerateToken()
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            
            byte[] key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("GYMT_SECRET") ?? "This should probably not be your key");
            
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AccountDashboard GetDashboard()
        {
            return new AccountDashboard()
            {
                Nickname = Nickname
            };
        }
    }
}