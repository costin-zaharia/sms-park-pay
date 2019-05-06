using Android.App;
using Android.Widget;
using SmsParkPay.Services;

namespace SmsParkPay.Droid.Services
{
    public class MessageService : IMessageService
    {
        public void LongAlert(string message)
            => Toast.MakeText(Application.Context, message, ToastLength.Long)
                    .Show();

        public void ShortAlert(string message)
            => Toast.MakeText(Application.Context, message, ToastLength.Short)
                    .Show();
    }
}