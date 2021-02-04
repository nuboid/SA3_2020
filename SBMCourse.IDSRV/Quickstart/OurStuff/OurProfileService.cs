using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SDPCloud.IdentityServer.Quickstart.OurStuff
{
    public class OurProfileService : IProfileService
    {

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {

            context.IssuedClaims = new System.Collections.Generic.List<Claim>();
            context.IssuedClaims.Add(new Claim("ourclaimwithid", context.Subject.Identity.Name)); 
            context.IssuedClaims.Add(new Claim("ourclaim1", "yes"));
            context.IssuedClaims.Add(new Claim("ourclaim2", "no"));
            
        }

        private List<Claim> GetClaimsFor(string? identityName)
        {
            throw new System.NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }       
    }
}
