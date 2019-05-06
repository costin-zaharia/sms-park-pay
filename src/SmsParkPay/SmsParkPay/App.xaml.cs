using SmsParkPay.Features.Main;
using SmsParkPay.Localization;
using SmsParkPay.Services;
using Xamarin.Forms;

namespace SmsParkPay
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var localizationService = DependencyService.Get<ILocalizationService>();

                var ci = localizationService.GetCurrentCultureInfo();
                Strings.Culture = ci;
                localizationService.SetLocale(ci);
            }

            MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
		}

		protected override void OnResume ()
		{
		}
	}
}
