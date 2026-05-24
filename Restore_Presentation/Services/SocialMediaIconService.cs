using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Services.Navigation;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class SocialMediaIconService : ISocialMediaIconService
{
    private readonly IUmbracoContextAccessor _contextAccessor;
    private readonly IDocumentNavigationQueryService _documentNavigationQueryService;
    private readonly ILogger<SocialMediaIconService> _logger;
    private readonly IBlockListService _blockListService;

    public SocialMediaIconService(IUmbracoContextAccessor contextAccessor,
        IDocumentNavigationQueryService documentNavigationQueryService, ILogger<SocialMediaIconService> logger, IBlockListService blockListService)
    {
        _contextAccessor = contextAccessor;
        _documentNavigationQueryService = documentNavigationQueryService;
        _logger = logger;
        _blockListService = blockListService;
    }

    public SocialMediaIconViewModel GetSocialMediaIconViewModel()
    {
        if (!_contextAccessor.TryGetUmbracoContext(out var umbracoContext))
        {
            _logger.LogWarning("Could not get context for the social media icons.");
            return new SocialMediaIconViewModel();
        }

        var content = umbracoContext.Content;
        if (content == null) return new SocialMediaIconViewModel();

        if (!_documentNavigationQueryService.TryGetRootKeysOfType("homePage", out var rootKeys))
            return new SocialMediaIconViewModel();

        if (content.GetById(rootKeys.First()) is not HomePage homePage)
        {
            _logger.LogWarning("Could not get the home page for the social media icons.");
            return new SocialMediaIconViewModel();
        }

        return new SocialMediaIconViewModel
        {
            SocialMediaIcons = _blockListService.GetBlockListContent<SocialMediaItem>(homePage.SocialMediaItems)
        };
    }
}
