using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class JwtTokenManager
    {
        private UserManager<User> UserManager { get; }
        private JwtConfig JwtConfig { get; }

        public JwtTokenManager(IOptions<JwtConfig> options, UserManager<User> userManager)
        {
            UserManager = userManager;
            JwtConfig = options.Value;
        }
        
        public async Task<string> GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConfig.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expireAt = DateTime.Now.AddMinutes(JwtConfig.AccessTokenExpiration);
            var claims = await UserManager.GetClaimsAsync(user);
            var jwtToken = new JwtSecurityToken(
                JwtConfig.Issuer,
                JwtConfig.Audience,
                claims,
                expires: expireAt,
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }
    }
}