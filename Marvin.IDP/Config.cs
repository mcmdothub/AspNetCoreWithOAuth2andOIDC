using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Marvin.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            // required scope for OIDC
            // unables claims: sub (user identifier)
            new IdentityResources.OpenId(), 
            // Add scope for profile
            // unables claims: name, family_name, given_name ... birthdate, zoneinfo, locale, updated_at
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            { 
                new Client()
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,                    // we work with code flow so we use code
                    // the code is delivered to the browser via URI redirection
                    // we add a valid URI where this client is allowed to receive tokens on
                    // the URI is the host address of our "ImageGallery.Client" web application followe by "signin-oidc"
                    RedirectUris =
                    {
                        "https://localhost:7192/signin-oidc"                // See project: "ImageGallery.Client" 
                    },
                    // we configure which scopes are allowed for our client
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    // we need to configure a client secret for client authentication to allow client application to execute an authenticated call to the token endpoint
                    // we give a secret, the value is ""<secret and we hash it so it can safely be stored 
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
}