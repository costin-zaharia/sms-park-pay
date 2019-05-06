namespace SmsParkPay.Features.Settings
{
    public interface ISettingsService
    {
        string LicensePlate { get; }

        string PhoneNumber { get; }
    }
}
