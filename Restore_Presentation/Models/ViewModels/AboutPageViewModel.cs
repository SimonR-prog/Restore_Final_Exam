using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Models.ViewModels;

public class AboutPageViewModel : PageViewModel<AboutPage>
{
    public AboutPageViewModel(AboutPage content, IPublishedValueFallback publishedValueFallback) : 
        base(content, publishedValueFallback)
    {
    }
    // Title:
    public string? Title { get; set; }

    // CTA:
    public Link? CallToAction { get; set; }

    // Personal information:
    public string? FullName { get; set; }
    public string? JobTitle { get; set; }
    public IHtmlEncodedString? Text { get; set; }

    // Image:
    public string? Image { get; set; }
    public string? Alt { get; set; }

}
