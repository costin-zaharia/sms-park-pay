using System.Globalization;

namespace SmsParkPay.Services
{
    public interface ILocalizationService
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}
