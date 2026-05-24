using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Presentation.Models.ViewModels;

public class PageViewModel<T> : PublishedContentModel, IBaseCmp where T : IBaseCmp
{
    private readonly IPublishedValueFallback _publishedValueFallback;

    public T Content { get; }

    public PageViewModel(T content, IPublishedValueFallback publishedValueFallback)
        : base(content, publishedValueFallback)
    {
        Content = content;
        _publishedValueFallback = publishedValueFallback;
    }

    public string? MetaDescription => BaseCmp.GetMetaDescription(this, _publishedValueFallback);
}