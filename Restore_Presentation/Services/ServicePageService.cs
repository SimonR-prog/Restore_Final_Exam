using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class ServicePageService : IServicePageService
{
    private readonly IPublishedValueFallback _publishedValueFallback;
    private readonly IBlockListService _blockListService;

    public ServicePageService(IPublishedValueFallback publishedValueFallback, IBlockListService blockListService)
    {
        _publishedValueFallback = publishedValueFallback;
        _blockListService = blockListService;
    }
    public ServicePageViewModel GetViewModel(ServicePage servicePage)
    {
        return new ServicePageViewModel(servicePage, _publishedValueFallback)
        {
            // Service items:
            Services = _blockListService.GetBlockListContent<ServiceItem>(servicePage.Services),

            // Title:
            Title = servicePage.Title,

            // CTA:
            CallToAction = servicePage.CallToAction,
        };
    }
}
