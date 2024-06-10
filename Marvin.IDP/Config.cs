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
            { };
}