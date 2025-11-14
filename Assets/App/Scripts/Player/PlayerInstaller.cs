using VContainer;
using VContainer.Unity;

namespace App.Player
{
    public static class PlayerInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<PlayerFactory>(Lifetime.Singleton);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<PlayerService>();
            });
        }
    }
}