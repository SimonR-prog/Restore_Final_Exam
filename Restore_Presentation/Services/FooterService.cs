using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Services.Navigation;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services;

public class FooterService : IFooterService
{
    private readonly IUmbracoContextAccessor _contextAccessor;
    private readonly IDocumentNavigationQueryService _documentNavigationQueryService;
    private readonly ILogger<FooterService> _logger;
    private readonly IPhoneNumberService _phoneNumberService;

    public FooterService(IUmbracoContextAccessor contextAccessor, ILogger<FooterService> logger, IDocumentNavigationQueryService documentNavigationQueryService, IPhoneNumberService phoneNumberService)
    {
        _contextAccessor = contextAccessor;
        _logger = logger;
        _documentNavigationQueryService = documentNavigationQueryService;
        _phoneNumberService = phoneNumberService;
    }

    public FooterViewModel GetFooterViewModel()
    {
        if (!_contextAccessor.TryGetUmbracoContext(out var umbracoContext))
        {
            _logger.LogWarning("Could not get context for the footer.");
            return new FooterViewModel();
        }

        var content = umbracoContext.Content;
        if (content == null)
            return new FooterViewModel();

        if (!_documentNavigationQueryService.TryGetRootKeysOfType("homePage", out var rootKeys))
            return new FooterViewModel();

        var homePage = content.GetById(rootKeys.First());
        if (homePage == null)
            return new FooterViewModel();

        var contactPage = homePage.DescendantsOrSelf<ContactPage>().FirstOrDefault();
        if (contactPage == null)
        {
            _logger.LogWarning("Could not get contact page for the footer.");
            return new FooterViewModel();
        }

        return new FooterViewModel
        {
            // Address:
            Adress = contactPage.Adress,
            Postal = contactPage.Postal,
            City = contactPage.City,

            // Contact info:
            Email = contactPage.Email,
            PhoneNumber = contactPage.PhoneNumber,
            PhoneNumberHref = _phoneNumberService.PhoneNumberHrefMaker(contactPage.PhoneNumber),

            // Opening hours:
            LineOne = contactPage.LineOne,
            LineTwo = contactPage.LineTwo,
            LineThree = contactPage.LineThree
        };
    }
}
