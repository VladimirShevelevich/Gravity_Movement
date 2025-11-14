using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Player
{
    public class PlayerFactory : IInitializable
    {
        private readonly IObjectResolver _objectResolver;
        private readonly PlayerContent _playerContent;

        public PlayerFactory(PlayerContent playerContent, IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
            _playerContent = playerContent;
        }
        
        public void Initialize()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            var go = Object.Instantiate(_playerContent.PlayerPrefab);
            _objectResolver.InjectGameObject(go);
        }
    }
}