using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmsParkPay.Features.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string VehicleNumberKey = "LicensePlate";
        private const string PhoneNumberKey = "PhoneNumber";
        private const string DefaultPhoneNumber = "7420";

        public string LicensePlate
        {
            get
            {
                if (Application.Current.Properties.TryGetValue(VehicleNumberKey, out var vehicleNumber))
                    return (string)vehicleNumber;

                return string.Empty;
            }
        }

        public string PhoneNumber
        {
            get
            {
                if (Application.Current.Properties.TryGetValue(PhoneNumberKey, out var phoneNumber))
                    return (string)phoneNumber;

                return DefaultPhoneNumber;
            }
        }

        public Task Save(string vehicleNumber, string phoneNumber)
        {
            Application.Current.Properties[VehicleNumberKey] = vehicleNumber;
            Application.Current.Properties[PhoneNumberKey] = phoneNumber;

            return Application.Current.SavePropertiesAsync();
        }
    }
}
