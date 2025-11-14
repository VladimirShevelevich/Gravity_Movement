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
            var newGravity = Physics2D.gravity;
            var isInsideX = playerPosition.x > PlatformBounds.min.x && playerPosition.x < PlatformBounds.max.x;
            var isInsideY = playerPosition.y > PlatformBounds.min.y && playerPosition.y < PlatformBounds.max.y;

            if (playerPosition.y > PlatformBounds.max.y && isInsideX)
                newGravity = Vector2.down * _gravityContent.Gravity;
            else if (playerPosition.y < PlatformBounds.min.y && isInsideX)
                newGravity = Vector2.up * _gravityContent.Gravity;
            else if (playerPosition.x > PlatformBounds.max.x && isInsideY)
                newGravity = Vector2.left * _gravityContent.Gravity;
            else if (playerPosition.x < PlatformBounds.min.x && isInsideY)
                newGravity = Vector2.right * _gravityContent.Gravity;
            
            Physics2D.gravity = newGravity;
        }
    }
}