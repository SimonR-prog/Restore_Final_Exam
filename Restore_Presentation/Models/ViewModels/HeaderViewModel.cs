using Umbraco.Cms.Core.Models.PublishedContent;

namespace Restore_Presentation.Models.ViewModels;

public class HeaderViewModel
{
    public string? WebsiteName { get; set; }
    public IEnumerable<IPublishedContent>? PageLinks { get; set; }
}
