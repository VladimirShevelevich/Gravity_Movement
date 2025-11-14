using App.Content;
using App.Gravity;
using App.Input;
using App.Platform;
using App.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private ContentHolder _contentHolder;
        
        protected override void Configure(IContainerBuilder builder)
        {
            _contentHolder.Register(builder);
            PlayerInstaller.Install(builder);
            PlatformInstaller.Install(builder);
            GravityInstaller.Install(builder);
            InputInstaller.Install(builder);
        }
    }
}