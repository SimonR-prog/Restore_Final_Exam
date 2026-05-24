using Restore_Presentation.Models.ViewModels;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Services.Interfaces
{
    public interface IPageNotFoundService
    {
        PageNotFoundViewModel GetViewModel(PageNotFound pageNotFound);
    }
}