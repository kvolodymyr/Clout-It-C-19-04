using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationIndetity.Models;

namespace WebApplicationIndetity.App_Start
{
    public class AppUserClaimsIdentityFactory : ClaimsIdentityFactory<AppUser>
    {
        public async override Task<ClaimsIdentity> CreateAsync(UserManager<AppUser, string> manager, AppUser user, string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));

            return identity;
        }
    }
}