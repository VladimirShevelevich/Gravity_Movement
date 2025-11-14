using VContainer;
using VContainer.Unity;

namespace App.Gravity
{
    public static class GravityInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<GravityAdjuster>();
            });
        }
    }
}