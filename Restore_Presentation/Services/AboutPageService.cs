using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class AboutPageService : IAboutPageService
{
    private readonly IPublishedValueFallback _publishedValueFallback;

    public AboutPageService(IPublishedValueFallback publishedValueFallback)
    {
        _publishedValueFallback = publishedValueFallback;
    }
    public AboutPageViewModel GetViewModel(AboutPage aboutPage)
    {
        return new AboutPageViewModel(aboutPage, _publishedValueFallback)
        {
            // Title:
            Title = aboutPage.Title,

            // Personal information:
            FullName = aboutPage.FullName,
            JobTitle = aboutPage.JobTitle,
            Text = aboutPage.Text,

            // CTA:
            CallToAction = aboutPage.CallToAction,

            // Image:
            Image = aboutPage.Image?.Url(),
            Alt = aboutPage.Alt
        };
    }
}
