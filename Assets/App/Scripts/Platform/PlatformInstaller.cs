using VContainer;
using VContainer.Unity;

namespace App.Platform
{
    public static class PlatformInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<PlatformFactory>(Lifetime.Singleton).AsSelf();
            builder.UseEntryPoints(ep =>
            {
                ep.Add<PlatformService>();
            });
        }
    }
}