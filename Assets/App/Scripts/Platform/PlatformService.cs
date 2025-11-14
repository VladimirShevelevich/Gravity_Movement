using UnityEngine;
using VContainer.Unity;

namespace App.Platform
{
    public class PlatformService : IInitializable
    {
        public Bounds PlatformBounds =>
            _view.GetBounds();
        
        private readonly PlatformFactory _platformFactory;
        private PlatformView _view;

        public PlatformService(PlatformFactory platformFactory)
        {
            _platformFactory = platformFactory;
        }

        public void Initialize()
        {
            _view = _platformFactory.Create();
        }
    }
}