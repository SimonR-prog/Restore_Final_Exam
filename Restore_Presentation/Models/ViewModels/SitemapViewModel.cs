using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Models.ViewModels;

public class SitemapViewModel : Sitemap
{
    public SitemapViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : 
        base(content, publishedValueFallback)
    {
    }

    public IEnumerable<IPublishedContent>? Pages { get; set; }
}
