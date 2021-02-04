using System.Collections.Generic;
using IdentityServer4.Models;
namespace SBMCourse.IDSRV
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1"),
                new ApiScope("email"),
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("xxx"),
                new ApiScope("yyy"),
            };

        public static IEnumerable<ApiResource> GetApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api1", "My API", new[]
                {
                    "ourclaim",
                    "ourclaimwithid"
                })
            };

        public static IEnumerable<Client> Clients =>
          new Client[]
          {
                new Client
                {
                    ClientId = "client001",
                    AccessTokenType = AccessTokenType.Jwt,
                    //ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    ClientName = "client001",
                    AlwaysSendClientClaims = true,
                    Claims = new List<IdentityServer4.Models.ClientClaim>() { new ClientClaim("TTT","VVV","VTVT") },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AccessTokenLifetime = 60*60*24,
                    AllowAccessTokensViaBrowser = true,
                    AllowRememberConsent = true,
                    AllowedScopes =
                    {
                        "api1",
                        "xxx",
                        "openid",
                        "email",
                        "profile",
                    },
                    RedirectUris = { "http://localhost/mobileapp001.client" },
                },
                new Client
                {
                    ClientId = "client002",
                    AccessTokenType = AccessTokenType.Jwt,
                    //ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    ClientName = "client002",
                    AlwaysSendClientClaims = true,
                    Claims = new List<IdentityServer4.Models.ClientClaim>() { new ClientClaim("TTT","VVV","VTVT") },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AccessTokenLifetime = 60*60*24,
                    AllowAccessTokensViaBrowser = true,
                    AllowRememberConsent = true,
                    AllowedScopes =
                    {
                        "api1",
                        "xxx",
                        "openid",
                        "email",
                        "profile",
                    },
                    ClientSecrets = { new Secret("test".Sha256()) },

                    RedirectUris = { "http://localhost/mobileapp001.client" },
                }
          };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                //new IdentityResource()
                //{
                //    UserClaims = new List<string> { "ourclaim" ,"ourclaimwithid"}
                //},
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
    }
}
