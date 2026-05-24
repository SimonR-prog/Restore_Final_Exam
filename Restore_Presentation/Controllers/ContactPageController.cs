using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Controllers;

public class ContactPageController : RenderController
{
    private readonly IContactPageService _contactPageService;
    public ContactPageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor, IContactPageService contactPageService) :
        base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _contactPageService = contactPageService;
    }

    public override IActionResult Index()
    {
        if (CurrentPage is ContactPage contactPage)
        {
            var model = _contactPageService.GetViewModel(contactPage);
            return CurrentTemplate(model);
        }

        return View();
    }
}
