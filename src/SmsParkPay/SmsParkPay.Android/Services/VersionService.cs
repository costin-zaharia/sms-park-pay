using Android.App;
using Android.Content;
using Android.Content.PM;

namespace SmsParkPay.Droid.Services
{
    internal class VersionService : IVersionService
    {
        public string GetApplicationName()
            => Application.Context.ApplicationInfo.LoadLabel(Application.Context.PackageManager);

        public string GetVersionName()
            => GetVersionName(Application.Context);

        private string GetVersionName(Context context)
            => context.PackageManager
                      .GetPackageInfo(context.PackageName, PackageInfoFlags.MetaData)
                      .VersionName;
    }
}