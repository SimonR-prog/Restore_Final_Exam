using Microsoft.AspNetCore.Mvc;
using Restore_Presentation.Services.Interfaces;

namespace Restore_Presentation.Components;

public class HeaderViewComponent : ViewComponent
{
    private readonly IHeaderService _headerService;

    public HeaderViewComponent(IHeaderService headerService)
    {
        _headerService = headerService;
    }

    public IViewComponentResult Invoke()
    {
        var model = _headerService.GetHeaderViewModel();
        return View(model);
    }
}