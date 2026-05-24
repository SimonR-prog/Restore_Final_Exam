using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services.Navigation;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class HeaderService : IHeaderService
{
    private readonly IUmbracoContextAccessor _contextAccessor;
    private readonly IDocumentNavigationQueryService _documentNavigationQueryService;
    private readonly ILogger<HeaderService> _logger;

    public HeaderService(IUmbracoContextAccessor contextAccessor, ILogger<HeaderService> logger, IDocumentNavigationQueryService documentNavigationQueryService)
    {
        _contextAccessor = contextAccessor;
        _logger = logger;
        _documentNavigationQueryService = documentNavigationQueryService;
    }

    public HeaderViewModel GetHeaderViewModel()
    {
        if (!_contextAccessor.TryGetUmbracoContext(out var umbracoContext))
        {
            _logger.LogWarning("Could not get context for the header.");
            return new HeaderViewModel();
        }

        var content = umbracoContext.Content;
        if (content == null) return new HeaderViewModel();

        if (!_documentNavigationQueryService.TryGetRootKeysOfType("homePage", out var rootKeys)) 
            return new HeaderViewModel();

        if(content.GetById(rootKeys.First()) is not HomePage homePage)
        {
            _logger.LogWarning("Could not get the home page for the header.");
            return new HeaderViewModel();
        }

        return new HeaderViewModel
        {
            WebsiteName = homePage.WebsiteName,
            PageLinks = GetLinks(homePage)
        };
    }
    public static IEnumerable<IPublishedContent> GetLinks(IPublishedContent homePage)
    {
        return homePage?.Children?.Where(x => x.Name != "Inställningar" && x.Name != "Sitemap" && x.Name != "Page Not Found")
            ?? Enumerable.Empty<IPublishedContent>();
    }
}