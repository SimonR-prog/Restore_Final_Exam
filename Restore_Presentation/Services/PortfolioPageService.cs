using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class PortfolioPageService : IPortfolioPageService
{
    private readonly IPublishedValueFallback _publishedValueFallback;
    private readonly IBlockListService _blockListService;

    public PortfolioPageService(IPublishedValueFallback publishedValueFallback, IBlockListService blockListService)
    {
        _publishedValueFallback = publishedValueFallback;
        _blockListService = blockListService;
    }
    public PortfolioPageViewModel GetViewModel(PortfolioPage portfolioPage)
    {
        return new PortfolioPageViewModel(portfolioPage, _publishedValueFallback)
        {
            // Images:
            Images = _blockListService.GetBlockListContent<PortfolioItem>(portfolioPage.Images),

            // Title:
            Title = portfolioPage.Title,

            // CTA:
            CallToAction = portfolioPage.CallToAction,
        };
    }
}
