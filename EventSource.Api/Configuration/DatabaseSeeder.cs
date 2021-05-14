using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EventSource.Api.Configuration
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DatabaseSeeder(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedDatabaseAsync()
        {
            await RegisterAccountAsync("example0@example.org", "Password123$");
            await RegisterAccountAsync("example1@example.org", "Password123$");
            await RegisterAccountAsync("example2@example.org", "Password123$");
        }

        private Task<IdentityResult> RegisterAccountAsync(string email, string password)
        {
            return _userManager.CreateAsync(
                new ApplicationUser 
                {
                    Id = Guid.NewGuid().ToString(), 
                    Email = email,

                }, 
                password);
        }
    }
}