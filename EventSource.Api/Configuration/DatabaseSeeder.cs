using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EventSource.Api.Configuration
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DatabaseSeeder(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task SeedDatabaseAsync()
        {
            const string password = "Password123$";
            var applicationUser = new ApplicationUser
            {
                Id = "dc7af950-d6bd-4bf8-b867-2c94dc64e256",
                Email = "example0@example.org",
                UserName = "example0@example.org"

            };
            var signInResult = await LoginAsync(applicationUser, password).ConfigureAwait(false);
            if (!signInResult.Succeeded)
            {
                await RegisterAccountAsync(applicationUser, password).ConfigureAwait(false);
                await LoginAsync(applicationUser, password).ConfigureAwait(false);
            }
        }

        private Task<IdentityResult> RegisterAccountAsync(ApplicationUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        private Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password);
        }

        private Task<SignInResult> LoginAsync(ApplicationUser user, string password)
        {
            return _signInManager.CheckPasswordSignInAsync(user, password, false);
        }
    }
}