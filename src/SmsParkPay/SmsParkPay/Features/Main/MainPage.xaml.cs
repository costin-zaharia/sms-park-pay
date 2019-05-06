using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using SmsParkPay.Features.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmsParkPay.Features.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
	    public static readonly BindableProperty ChildrenProperty =
	        BindableProperty.Create(nameof(Children),
                                    typeof(IEnumerable<Page>),
                                    typeof(MainPage),
                                    null,
                                    BindingMode.TwoWay,
                                    propertyChanged: OnItemsSourcePropertyChanged);

        public MainPage ()
		{
			InitializeComponent();

            BindingContext = new MainPageViewModel(new SettingsService());
		}

	    public new IEnumerable<Page> Children
	    {
	        get => base.Children;
	        set => SetValue(ChildrenProperty, value);
	    }

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var tabbedPage = (TabbedPage) bindable;
            var pages = (IEnumerable<Page>) newValue;

            switch (newValue)
            {
                case null:
                    return;

                case INotifyCollectionChanged notifyCollection:
                    notifyCollection.CollectionChanged += (_, args) => HandleCollectionChanged(tabbedPage, args);
                    break;
            }

            tabbedPage.Children.Clear();

	        foreach (var item in pages)
	            tabbedPage.Children.Add(item);
	    }

	    private static void HandleCollectionChanged(TabbedPage tabbedPage, NotifyCollectionChangedEventArgs args)
	    {
	        if (args.NewItems != null)
	        {
	            foreach (var newItem in args.NewItems.OfType<Page>())
	            {
	                tabbedPage.Children.Add(newItem);
	            }
	        }

	        if (args.OldItems == null)
	            return;

	        foreach (var oldItem in args.OldItems.OfType<Page>())
	            tabbedPage.Children.Remove(oldItem);
        }
    }
}