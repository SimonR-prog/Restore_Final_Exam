using Microsoft.Extensions.Logging.Abstractions;
using Restore_Presentation.Services;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Restore_Testing.Service_Tests;

public class BlockListService_Tests
{
    private readonly BlockListService _blockListService = new BlockListService(new NullLogger<BlockListService>());

    [Fact]
    public void BlockListService_ShouldReturnEmptyListOfItems_IfNull_Input()
    {
        // Arrange:

        // Act:
        var result = _blockListService.GetBlockListContent<ServiceItem>(null);

        // Assert:
        Assert.Empty(result);
    }
}
