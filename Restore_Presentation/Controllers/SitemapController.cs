using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Controllers;

public class SitemapController : RenderController
{
    private readonly IPublishedValueFallback _publishedValueFallback;
    private readonly ISitemapService _sitemapService;

    public SitemapController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback, ISitemapService sitemapService) :
        base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _publishedValueFallback = publishedValueFallback;
        _sitemapService = sitemapService;
    }

    public override IActionResult Index()
    {
        if(CurrentPage is Sitemap sitemap)
        {
            var model = new SitemapViewModel(sitemap, _publishedValueFallback)
            {
                Pages = _sitemapService.Pages()
            };
            var xml = _sitemapService.CreateSitemapXml(model);

            return Content(xml, "text/xml");
        }
        return NotFound();
    }
}
