using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Models.ViewModels;

public class HomePageViewModel : PageViewModel<HomePage>
{
    public HomePageViewModel(HomePage content, IPublishedValueFallback publishedValueFallback) :
        base(content, publishedValueFallback)
    {
    }
    // Title:
    public string? Title { get; set; }

    // CTA:
    public Link? CallToAction { get; set; }

    // Image:
    public string? Image { get; set; }
    public string? Alt { get; set; }

    // Website:
    public string? WebsiteName { get; set; }

    // Social media:
    public IEnumerable<SocialMediaItem>? SocialMediaItems { get; set; }

}
