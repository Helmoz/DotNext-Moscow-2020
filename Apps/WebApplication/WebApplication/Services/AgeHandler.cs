using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Services
{
    public class AgeHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                if(int.TryParse(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth)?.Value, out var year))
                {
                    if (DateTime.Now.Year - year >= requirement.Age)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
    
    public class AgeRequirement : IAuthorizationRequirement
    {
        protected internal int Age { get; set; }
     
        public AgeRequirement(int age)
        {
            Age = age;
        }
    }
}