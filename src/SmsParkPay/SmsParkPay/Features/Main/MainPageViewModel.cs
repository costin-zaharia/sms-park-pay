using System.Collections.ObjectModel;
using System.Linq;
using SmsParkPay.Features.Common;
using SmsParkPay.Features.SendSMS;
using SmsParkPay.Features.Settings;
using SmsParkPay.Localization;
using SmsParkPay.Mixins;
using Xamarin.Forms;

namespace SmsParkPay.Features.Main
{
    public class MainPageViewModel : BaseViewModel
    {
        private Page _current;

        public ObservableCollection<Page> Pages { get; } = new ObservableCollection<Page>();

        public Page Current
        {
            get => _current;
            set => SetProperty(ref _current, value);
        }

        public MainPageViewModel(ISettingsService settingsService)
        {
            Pages.Add(new NavigationPage(new SendSMSPage())
                      {
                          Title = Strings.SMS
                      });

            Pages.Add(new NavigationPage(new SettingsPage())
                      {
                          Title = Strings.Settings
                      });

            Current = settingsService.PhoneNumber.IsNullOrEmpty() || settingsService.LicensePlate.IsNullOrEmpty()
                          ? Pages.Last()
                          : Pages.First();
        }
    }
}
