namespace Restore_Presentation.Models.ViewModels;

public class FooterViewModel
{
    // Address:
    public string? Adress { get; set; }
    public string? Postal { get; set; }
    public string? City { get; set; }

    // Contact info:
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhoneNumberHref { get; set; }

    // Opening hours:
    public string? LineOne { get; set; }
    public string? LineTwo { get; set; }
    public string? LineThree { get; set; }
}
