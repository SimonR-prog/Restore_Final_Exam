using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class HomePageService : IHomePageService
{
    private readonly IPublishedValueFallback _publishedValueFallback;
    private readonly IBlockListService _blockListService;

    public HomePageService(IPublishedValueFallback publishedValueFallback, IBlockListService blockListService)
    {
        _publishedValueFallback = publishedValueFallback;
        _blockListService = blockListService;
    }

    public HomePageViewModel GetViewModel(HomePage homePage)
    {
        return new HomePageViewModel(homePage, _publishedValueFallback)
        {
            // Socialmediaitems:
            SocialMediaItems = _blockListService.GetBlockListContent<SocialMediaItem>(homePage.SocialMediaItems),

            // Title:
            Title = homePage.Title,

            // Image:
            Image = homePage.Image?.Url(),
            Alt = homePage.Alt,

            // Website:
            WebsiteName = homePage.WebsiteName,

            // CTA:
            CallToAction = homePage.CallToAction
        };
    }
}
