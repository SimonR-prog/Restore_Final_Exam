using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Controllers;

public class PageNotFoundController : RenderController
{
    private readonly IPageNotFoundService _pageNotFoundService;
    public PageNotFoundController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor, IPageNotFoundService pageNotFoundService) : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _pageNotFoundService = pageNotFoundService;
    }

    public override IActionResult Index()
    {
        if (CurrentPage is PageNotFound pageNotFound)
        {
            var model = _pageNotFoundService.GetViewModel(pageNotFound);
            return CurrentTemplate(model);
        }

        return View();
    }
}
