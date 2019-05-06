using Plugin.Messaging;
using SmsParkPay.Features.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmsParkPay.Features.SendSMS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendSMSPage : ContentPage
	{
        public SendSMSPage()
        {
            InitializeComponent();

            BindingContext = new SendSMSViewModel(CrossMessaging.Current.SmsMessenger, new SettingsService());
        }
	}
}