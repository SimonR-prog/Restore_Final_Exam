using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Models.ViewModels;

public class ServicePageViewModel : PageViewModel<ServicePage>
{
    public ServicePageViewModel(ServicePage content, IPublishedValueFallback publishedValueFallback) :
        base(content, publishedValueFallback)
    {
    }
    // Title:
    public string? Title { get; set; }

    // CTA:
    public Link? CallToAction { get; set; }

    // Services:
    public IEnumerable<ServiceItem>? Services { get; set; }
}
