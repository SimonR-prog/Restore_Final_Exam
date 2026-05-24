using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Controllers;

public class ServicePageController : RenderController
{
    private readonly IServicePageService _servicePageService;
    public ServicePageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor, IServicePageService servicePageService) :
        base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _servicePageService = servicePageService;
    }

    public override IActionResult Index()
    {
        if (CurrentPage is ServicePage servicePage)
        {
            var model = _servicePageService.GetViewModel(servicePage);
            return CurrentTemplate(model);
        }

        return View();
    }
}
