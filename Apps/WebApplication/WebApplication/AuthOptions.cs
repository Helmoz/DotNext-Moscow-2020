using Microsoft.AspNetCore.Identity;

namespace WebApplication
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        
        public string Issuer { get; set; }
        
        public string Audience { get; set; }

        public int AccessTokenExpiration { get; set; }
    }
    
    public class AuthOptions
    {
        public static void IdentityOptions(IdentityOptions options)
        {
            options.Stores.MaxLengthForKeys = 128;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        }
    }
}