using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Controllers;

public class HomePageController : RenderController
{
    private readonly IHomePageService _homePageService;
    public HomePageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor, IHomePageService homePageService) :
        base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _homePageService = homePageService;
    }

    public override IActionResult Index()
    {
        if (CurrentPage is HomePage homePage)
        {
            var model = _homePageService.GetViewModel(homePage);
            return CurrentTemplate(model);
        }

        return View();
    }
}
