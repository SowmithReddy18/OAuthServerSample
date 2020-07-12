using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClassRoom.OAuth.IDPConfiguration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("classprojects", "Class Projects")
            };
        }

        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[] {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
        public static IEnumerable<Client> Clients()
        {
            return new[]
            {
                new Client()
                {
                    ClientId = "AppUser",
                    ClientSecrets = new[]
                    {
                        new Secret("usersecret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new[]{"classprojects"}
                },
                new Client()
                {
                    ClientId = "AppUser_Implicit",
                    ClientSecrets = new[]
                    {
                        new Secret("usersecret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new[]{
                        "classprojects",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                        },
                    RedirectUris= new []{ "http://localhost:4200/home","http://localhost:4200/signin-callback" },
                    PostLogoutRedirectUris = new []{ "http://localhost:4200/signout-callback" }
                }
            };
        }
        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser()
                {
                    SubjectId ="1",
                    Username="test1@test.com",
                    Password="Test123!",
                    Claims = new []{
                        new Claim("name","Sowmith Reddy M"),
                        new Claim("nickname", "Sonu")
                        }

                },
                new TestUser()
                {
                    SubjectId = "2",
                    Username="test2@test.com",
                    Password="Test123!"
                }
            };
        }
    }
}
