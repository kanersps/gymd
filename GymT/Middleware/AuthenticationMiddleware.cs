using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymT.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace GymT.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IGymTDbContext dbContext)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
                await AttachAccount(context, dbContext, token);
            
            await _next(context);
        }

        private async Task AttachAccount(HttpContext context, IGymTDbContext _unitOfWork, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("GYMT_SECRET") ?? "This should probably not be your key");
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                
                context.Items["AccountId"] = _unitOfWork.Accounts.FirstOrDefault(account => account.Id == new Guid(userId))?.Id;
            }
            catch
            {
                // ignored
            }
        }
    }
}