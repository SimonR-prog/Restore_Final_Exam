using Restore_Presentation.Services;
using Restore_Presentation.Services.Interfaces;

namespace Restore_Presentation.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IBlockListService, BlockListService>(); 
        services.AddScoped<ISitemapService, SitemapService>();
        services.AddScoped<IFooterService, FooterService>();
        services.AddScoped<IHeaderService, HeaderService>();
        services.AddScoped<ISocialMediaIconService, SocialMediaIconService>();
        services.AddScoped<IPhoneNumberService, PhoneNumberService>();

        services.AddScoped<IAboutPageService, AboutPageService>();
        services.AddScoped<IContactPageService, ContactPageService>();
        services.AddScoped<IHomePageService, HomePageService>();
        services.AddScoped<IPortfolioPageService, PortfolioPageService>();
        services.AddScoped<IServicePageService, ServicePageService>();
        services.AddScoped<IPageNotFoundService, PageNotFoundService>();

        return services;
    }
}
