using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Controllers;

public class PortfolioPageController : RenderController
{
    private readonly IPortfolioPageService _portfolioPageService;
    public PortfolioPageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor, IPortfolioPageService portfolioPageService) :
        base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _portfolioPageService = portfolioPageService;
    }

    public override IActionResult Index()
    {
        if (CurrentPage is PortfolioPage portfolioPage)
        {
            var model = _portfolioPageService.GetViewModel(portfolioPage);
            return CurrentTemplate(model);
        }

        return View();
    }
}
