using Microsoft.Extensions.DependencyInjection;


namespace SDPCloud.IdentityServer.Quickstart.OurStuff
{
    public static class OurCustomIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddAddOurStuff(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IOurUserRepository, OurUserRepository>();
            builder.AddProfileService<OurProfileService>();

            return builder;
        }
    }
}
