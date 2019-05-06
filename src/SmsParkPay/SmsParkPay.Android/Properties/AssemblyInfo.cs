using System.Reflection;
using System.Runtime.InteropServices;
using Android.App;
using SmsParkPay.Droid.Services;
using Xamarin.Forms;

[assembly: AssemblyTitle("SmsParkPay.Android")]
[assembly: AssemblyProduct("SmsParkPay.Android")]
[assembly: AssemblyCopyright("Copyright © Costin Zaharia 2018")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]

[assembly: Dependency(typeof(MessageService))]
[assembly: Dependency(typeof(VersionService))]
[assembly: Dependency(typeof(LocalizationService))]
