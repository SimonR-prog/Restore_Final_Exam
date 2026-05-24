using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Models.ViewModels;

public class PortfolioPageViewModel : PageViewModel<PortfolioPage>
{
    public PortfolioPageViewModel(PortfolioPage content, IPublishedValueFallback publishedValueFallback) :
        base(content, publishedValueFallback)
    {
    }
    // Title:
    public string? Title { get; set; }

    // CTA:
    public Link? CallToAction { get; set; }

    // Images:
    public IEnumerable<PortfolioItem>? Images { get; set; }
}