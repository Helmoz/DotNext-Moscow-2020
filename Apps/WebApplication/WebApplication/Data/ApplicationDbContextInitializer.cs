using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ApplicationDbContextInitializer : IAsyncInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly bool _needSeed;

        public ApplicationDbContextInitializer(ApplicationDbContext context, UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _needSeed = configuration.GetValue<bool>("Initialize");
        }

        private async Task Seed()
        {
            var users = new List<User>
            {
                new() { UserName = "test@test.ru", Email = "test@test.ru", BirthDate = new DateTime(2005, 1, 20)},
                new() { UserName = "test1@test.ru", Email = "test1@test.ru", BirthDate = new DateTime(2000, 1, 20)}
            };
            foreach (var user in users)
            {
                var result = await _userManager.CreateAsync(user, user.Email);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName));
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.DateOfBirth, user.BirthDate.Year.ToString()));
                }
            }

            await _roleManager.CreateAsync(new IdentityRole(User.AdminRole));
            await CreateAdmin(users.FirstOrDefault());
        }

        private async Task CreateAdmin(User user)
        {
            var addToRoleResult = await _userManager.AddToRoleAsync(user, User.AdminRole);

            if (addToRoleResult.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimsIdentity.DefaultRoleClaimType, User.AdminRole));
            }
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();
            if (_needSeed)
            {
                await Seed();
            }
        }
    }
}