using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("ResourceCatalog")
        {
            Scopes = { "CatalogFullPermission", "CatalogReadPermission" }
        },

        new ApiResource("ResourceDiscount")
        {
            Scopes = { "DiscountFullPermission" }
        },

        new ApiResource("ResourceOrder")
        {
            Scopes = { "OrderFullPermission" }
        },

        new ApiResource("ResourceCargo")
        {
            Scopes = { "CargoFullPermission", "CargoReadPermission" }
        },

        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Fully authoritized for catalog operations"),
            new ApiScope("CatalogReadPermission", "Partially authorized for reading operations only" ),
            new ApiScope("DiscountFullPermission", "Fully authorized for discount operations"),
            new ApiScope("OrderFullPermission", "Fully authorized for order operations"),
            new ApiScope("CargoFullPermission", "Fully authorized for cargo operations"),
            new ApiScope("CargoReadPermission", "Partially authorized for reading operations only" ),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            //Visitor Client
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "CatalogReadPermission" }
            },

            //Admin Client
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //RedirectUris = { "https://localhost:44300/signin-oidc" },
                //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //AllowOfflineAccess = true,
                AllowedScopes =
                {
                    "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission", "CargoReadPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 86400
            },

            //Manager Client
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("8A5C6698-4F09-45CA-AAE3-CF2D22618BC8".Sha256()) },

                //RedirectUris = { "https://localhost:44300/signin-oidc" },
                //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //AllowOfflineAccess = true,
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission" }
            },
        };
}
