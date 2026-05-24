using Microsoft.AspNetCore.Mvc;
using Restore_Presentation.Services.Interfaces;

namespace Restore_Presentation.Components;

public class SocialMediaIconViewComponent : ViewComponent
{
    private readonly ISocialMediaIconService _socialMediaIconService;

    public SocialMediaIconViewComponent(ISocialMediaIconService socialMediaIconService)
    {
        _socialMediaIconService = socialMediaIconService;
    }

    public IViewComponentResult Invoke()
    {
        var model = _socialMediaIconService.GetSocialMediaIconViewModel();
        return View(model);
    }
}
