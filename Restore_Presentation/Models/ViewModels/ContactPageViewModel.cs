using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Models.ViewModels;

public class ContactPageViewModel : PageViewModel<ContactPage>
{
    public ContactPageViewModel(ContactPage content, IPublishedValueFallback publishedValueFallback) :
        base(content, publishedValueFallback)
    {
    }
    // Title:
    public string? Title { get; set; }
    public string? ContactTitle { get; set; }

    // Address:
    public string? Adress { get; set; }
    public string? Postal { get; set; }
    public string? City { get; set; }

    // Contact info:
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhoneNumberHref { get; set; }

    // Opening hours:
    public string? LineOne { get; set; }
    public string? LineTwo { get; set; }
    public string? LineThree { get; set; }
}