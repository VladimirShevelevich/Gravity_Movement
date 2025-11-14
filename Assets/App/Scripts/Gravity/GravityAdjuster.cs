using App.Platform;
using App.Player;
using VContainer.Unity;
using UniRx;
using UnityEngine;

namespace App.Gravity
{
    public class GravityAdjuster : IInitializable
    {        
        private readonly IPlayerService _playerService;
        private readonly IPlatformService _platformService;
        private readonly GravityContent _gravityContent;
        
        public GravityAdjuster(IPlayerService playerService, IPlatformService platformService, GravityContent gravityContent)
        {
            _playerService = playerService;
            _platformService = platformService;
            _gravityContent = gravityContent;
        }
        
        public void Initialize()
        {
            _playerService.PlayerPosition.Subscribe(OnPlayerPositionChange);
        }

        private Bounds PlatformBounds => 
            _platformService.PlatformBounds;

        private void OnPlayerPositionChange(Vector3 position)
        {
            AdjustGravity(position);
        }

        private void AdjustGravity(Vector3 playerPosition)
        {
            Vector2 newGravity;
            newGravity = playerPosition.y >= PlatformBounds.center.y ?
                new Vector2(0, -_gravityContent.Gravity) :
                new Vector2(0, _gravityContent.Gravity);

            Physics2D.gravity = newGravity;
        }
    }
}