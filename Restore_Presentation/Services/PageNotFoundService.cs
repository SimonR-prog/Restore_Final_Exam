using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class PageNotFoundService : IPageNotFoundService
{
    private readonly IPublishedValueFallback _publishedValueFallback;

    public PageNotFoundService(IPublishedValueFallback publishedValueFallback)
    {
        _publishedValueFallback = publishedValueFallback;
    }
    public PageNotFoundViewModel GetViewModel(PageNotFound pageNotFound)
    {
        return new PageNotFoundViewModel(pageNotFound, _publishedValueFallback)
        {
            // Title:
            Title = pageNotFound.Title,

            // CTA:
            CallToAction = pageNotFound.CallToAction
        };
    }
}
