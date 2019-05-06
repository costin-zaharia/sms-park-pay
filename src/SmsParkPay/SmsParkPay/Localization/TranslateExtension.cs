using SmsParkPay.Services;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmsParkPay.Localization
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo ci = null;

        public string Text { get; set; }

        public TranslateExtension()
        {
            if (Device.RuntimePlatform == Device.iOS ||
                Device.RuntimePlatform == Device.Android)
            {
                ci = DependencyService.Get<ILocalizationService>().GetCurrentCultureInfo();
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            return Strings.ResourceManager.GetString(Text, ci) ?? Strings.ResourceManager.GetString(Text);
        }
    }
}
