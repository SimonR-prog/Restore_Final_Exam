using Microsoft.AspNetCore.Mvc;
using Restore_Presentation.Services.Interfaces;

namespace Restore_Presentation.Components;

public class FooterViewComponent : ViewComponent
{
    private readonly IFooterService _footerService;

    public FooterViewComponent(IFooterService footerService)
    {
        _footerService = footerService;
    }

    public IViewComponentResult Invoke()
    {
        var model = _footerService.GetFooterViewModel();
        return View(model);
    }
}
