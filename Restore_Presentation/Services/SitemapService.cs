using Restore_Presentation.Models.ViewModels;
using Restore_Presentation.Services.Interfaces;
using System.Text;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services.Navigation;
using Umbraco.Cms.Core.Web;

namespace Restore_Presentation.Services;

public class SitemapService : ISitemapService
{
    private readonly IUmbracoContextAccessor _contextAccessor;
    private readonly IDocumentNavigationQueryService _documentNavigationQueryService;
    private readonly ILogger<SitemapService> _logger;

    public SitemapService(IUmbracoContextAccessor contextAccessor, IDocumentNavigationQueryService documentNavigationQueryService,
        ILogger<SitemapService> logger)
    {
        _contextAccessor = contextAccessor;
        _documentNavigationQueryService = documentNavigationQueryService;
        _logger = logger;
    }

    public IEnumerable<IPublishedContent> Pages()
    {
        if (!_contextAccessor.TryGetUmbracoContext(out var umbracoContext))
        {
            return Enumerable.Empty<IPublishedContent>();
        }

        var content = umbracoContext.Content;
        if (content == null)
        {
            return Enumerable.Empty<IPublishedContent>();
        }

        if (!_documentNavigationQueryService.TryGetRootKeysOfType("homePage", out var rootKeys))
        {
            return Enumerable.Empty<IPublishedContent>();
        }

        var homePage = content.GetById(rootKeys.First());
        if (homePage == null)
        {
            return Enumerable.Empty<IPublishedContent>();
        }

        return homePage.DescendantsOrSelf<IPublishedContent>()
            .Where(page => page.HasProperty("metaDescription")
            && page.ContentType.Alias != "pageNotFound"
            && page.IsPublished()).ToList();
    }

    public string CreateSitemapXml(SitemapViewModel model)
    {
        if (_contextAccessor.TryGetUmbracoContext(out var umbracoContext))
        {
            var currentCulture = umbracoContext.PublishedRequest?.Culture;
            var sb = new StringBuilder();

            var localizedPages = model.Pages
                .Where(page => page.IsPublished(currentCulture))
                .Select(page => new
                {
                    Page = page,
                    Url = page.Url(culture: currentCulture, mode: UrlMode.Absolute),
                    LastModified = page.UpdateDate
                })
                .ToList();

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<urlset xmlns=\"https://www.sitemaps.org/schemas/sitemap/0.9\">");

            foreach (var page in localizedPages)
            {
                sb.AppendLine($"<url><loc>{page.Url}</loc><lastmod>{page.LastModified:yyyy-MM-dd HH:mm:ss}</lastmod></url>");
            }

            sb.AppendLine("</urlset>");

            return sb.ToString();
        }
        _logger.LogInformation("");
        return string.Empty;
    }
}