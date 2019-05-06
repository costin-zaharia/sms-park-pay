using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmsParkPay.Features.Settings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
	    private readonly SettingsViewModel _viewModel;

		public SettingsPage()
		{
		    InitializeComponent();

		    _viewModel = new SettingsViewModel();

            BindingContext = _viewModel;
		}

        private void OnSettingsPageDissapearing(object sender, EventArgs e)
            => _viewModel.Save();
    }
}