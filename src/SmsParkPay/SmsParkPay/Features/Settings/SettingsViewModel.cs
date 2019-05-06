using System.Windows.Input;
using SmsParkPay.Droid.Services;
using SmsParkPay.Features.Common;
using SmsParkPay.Localization;
using SmsParkPay.Services;
using Xamarin.Forms;

namespace SmsParkPay.Features.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private string _licensePlate = string.Empty;
        private string _phoneNumber = string.Empty;
        private FormattedString _appInfo;

        private readonly SettingsService _settingsService = new SettingsService();
        private readonly IMessageService _messageService;

        public SettingsViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();

            SaveCommand = new Command(Save);

            Load();
        }

        public ICommand SaveCommand { get; }

        public string LicensePlate
        {
            get => _licensePlate;
            set => SetProperty(ref _licensePlate, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        public FormattedString AppInfo
        {
            get => _appInfo;
            set => SetProperty(ref _appInfo, value);
        }

        private void Load()
        {
            AppInfo = GetAppInfo();
            LicensePlate = _settingsService.LicensePlate;
            PhoneNumber = _settingsService.PhoneNumber;
        }

        public async void Save()
        {
            if (!HasChanged())
                return;

            await _settingsService.Save(LicensePlate, PhoneNumber);

            _messageService.ShortAlert(Strings.SettingsSaved);
        }

        private bool HasChanged()
            => _settingsService.LicensePlate != LicensePlate ||
               _settingsService.PhoneNumber != PhoneNumber;

        private FormattedString GetAppInfo()
            => new FormattedString
            {
                Spans =
                    {
                        new Span
                        {
                            Text = DependencyService.Get<IVersionService>().GetApplicationName(),
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 22
                        },
                        new Span
                        {
                            Text = " "
                        },
                        new Span
                        {
                            Text = DependencyService.Get<IVersionService>().GetVersionName()
                        }
                    }
            };
    }
}
