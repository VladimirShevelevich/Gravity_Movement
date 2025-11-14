using VContainer;
using VContainer.Unity;

namespace App.Input
{
    public static class InputInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<InputService>();
            });

            RegisterInputHandlers(builder);
        }

        private static void RegisterInputHandlers(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<KeyboardInputHandler>();
            });
        }
    }
}