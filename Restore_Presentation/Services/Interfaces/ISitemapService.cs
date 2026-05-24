using Restore_Presentation.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Restore_Presentation.Services.Interfaces
{
    public interface ISitemapService
    {
        string CreateSitemapXml(SitemapViewModel model);
        IEnumerable<IPublishedContent> Pages();
    }
}