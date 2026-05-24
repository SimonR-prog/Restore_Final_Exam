using Restore_Presentation.Services.Interfaces;
using Umbraco.Cms.Core.Models.Blocks;

namespace Restore_Presentation.Services;

public class BlockListService(ILogger<BlockListService> logger) : IBlockListService
{
    private readonly ILogger<BlockListService> _logger = logger;

    public IEnumerable<T> GetBlockListContent<T>(BlockListModel? content) where T : class
    {
        try
        {
            if (content == null)
            {
                _logger.LogError($"{content} is found to be null. Error from BlockListService.");
                return Enumerable.Empty<T>();
            }
            if (!content.Any())
            {
                _logger.LogError($"{content} is found to be empty. Error from BlockListService.");
                return Enumerable.Empty<T>();
            }

            return content.Select(item => item.Content).OfType<T>().ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Enumerable.Empty<T>();
        }
    }
}
