using App.Content;
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
            builder.UseEntryPoints(ep =>
            {
                ep.Add<PlayerFactory>();
            });
        }
    }
}