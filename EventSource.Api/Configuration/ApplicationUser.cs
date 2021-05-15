using System.Collections.Generic;
using Marten.AspNetIdentity;
using Microsoft.AspNetCore.Identity;

namespace EventSource.Api.Configuration
{
    public class ApplicationUser : IdentityUser, IClaimsUser
    {
        public IList<string> RoleClaims { get; set; }
    }
}