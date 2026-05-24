using Umbraco.Cms.Core.Models.Blocks;

namespace Restore_Presentation.Services.Interfaces
{
    public interface IBlockListService
    {
        IEnumerable<T> GetBlockListContent<T>(BlockListModel? content) where T : class;
    }
}