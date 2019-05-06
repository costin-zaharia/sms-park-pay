using System.Windows.Input;
using Plugin.Messaging;
using SmsParkPay.Features.Common;
using SmsParkPay.Features.Settings;
using SmsParkPay.Mixins;
using Xamarin.Forms;

namespace SmsParkPay.Features.SendSMS
{
    public class SendSMSViewModel : BaseViewModel
    {
        private readonly ISmsTask _smsTask;
        private readonly ISettingsService _settingsService;

        public SendSMSViewModel(ISmsTask smsTask, ISettingsService settingsService)
        {
            _smsTask = smsTask;
            _settingsService = settingsService;

            SendSmsCommand = new Command<FareType>(SendSms);
        }

        public ICommand SendSmsCommand { get; }

        private void SendSms(FareType type)
        {
            if (!_smsTask.CanSendSms)
                return;

            if (_settingsService.LicensePlate.IsNullOrEmpty())
                return;

            if (_settingsService.PhoneNumber.IsNullOrEmpty())
                return;

            var message = type.GetMessage(_settingsService.LicensePlate);
            _smsTask.SendSms(_settingsService.PhoneNumber, message);
        }
    }
}
