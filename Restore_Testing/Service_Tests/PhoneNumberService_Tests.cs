using Microsoft.Extensions.Logging.Abstractions;
using Restore_Presentation.Services;

namespace Restore_Testing.Service_Tests;

public class PhoneNumberService_Tests
{
    private readonly PhoneNumberService _phoneNumberService = new PhoneNumberService(new NullLogger<PhoneNumberService>());

    [Theory]
    [InlineData("0555555555")]
    [InlineData("0555 55 55 55")]
    [InlineData("0555-55-55-55")]
    public void PhoneNumberHrefMaker_ShouldReturn_FixedNumber_IfValidInput(string validInput)
    {

        // Arrange:

        // Act:
        var result = _phoneNumberService.PhoneNumberHrefMaker(validInput);

        // Assert:
        Assert.False(string.IsNullOrWhiteSpace(result));
        Assert.Equal("46555555555", result);
    }

    [Theory]
    [InlineData("+46 55 5555 55 5")]
    [InlineData("46555555555")]
    [InlineData("55-55-555-55")]
    public void PhoneNumberHrefMaker_ShouldReturn_EmptyString_IfInvalidInput(string invalidInput)
    {

        // Arrange:

        // Act:
        var result = _phoneNumberService.PhoneNumberHrefMaker(invalidInput);

        // Assert:
        Assert.True(string.IsNullOrWhiteSpace(result));
    }
}
