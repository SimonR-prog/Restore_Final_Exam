using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class ContactPageService : IContactPageService
{
    private readonly IPublishedValueFallback _publishedValueFallback;
    private readonly IPhoneNumberService _phoneNumberService;

    public ContactPageService(IPublishedValueFallback publishedValueFallback, IPhoneNumberService phoneNumberService)
    {
        _publishedValueFallback = publishedValueFallback;
        _phoneNumberService = phoneNumberService;
    }
    public ContactPageViewModel GetViewModel(ContactPage contactPage)
    {
        return new ContactPageViewModel(contactPage, _publishedValueFallback)
        {
            // Phone number href:
            PhoneNumberHref = _phoneNumberService.PhoneNumberHrefMaker(contactPage.PhoneNumber),

            // Title:
            Title = contactPage.Title,
            ContactTitle = contactPage.ContactTitle,

            // Address:
            Adress = contactPage.Adress,
            Postal = contactPage.Postal,
            City = contactPage.City,

            // Contact info:
            Email = contactPage.Email,
            PhoneNumber = contactPage.PhoneNumber,

            // Opening hours:
            LineOne = contactPage.LineOne,
            LineTwo = contactPage.LineTwo,
            LineThree = contactPage.LineThree
        };
    }
}