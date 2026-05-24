using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Controllers;

public class AboutPageController : RenderController
{
    private readonly IAboutPageService _aboutPageService;
    public AboutPageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor, IAboutPageService aboutPageService) : 
        base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _aboutPageService = aboutPageService;
    }

    public override IActionResult Index()
    {
        if (CurrentPage is AboutPage aboutPage)
        {
            var model = _aboutPageService.GetViewModel(aboutPage);
            return CurrentTemplate(model);
        }

        return View();
    }
}
