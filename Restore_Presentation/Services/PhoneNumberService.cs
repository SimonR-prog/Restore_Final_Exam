using Restore_Presentation.Services.Interfaces;

namespace Restore_Presentation.Services;

public class PhoneNumberService : IPhoneNumberService
{
    private readonly ILogger<PhoneNumberService> _logger;
    public PhoneNumberService(ILogger<PhoneNumberService> logger)
    {
        _logger = logger;
    }

    public string PhoneNumberHrefMaker(string number)
    {
        if (!string.IsNullOrEmpty(number) && number.StartsWith("0", 0))
        {
            var cleanNumber = number.Trim().Replace(" ", "").Replace("-", "").Remove(0, 1);
            return number = "46" + cleanNumber;
        }
        _logger.LogWarning("Number in the CMS was invalid.");
        return string.Empty;
    }
}
