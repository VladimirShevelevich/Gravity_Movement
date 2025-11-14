using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Player
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly PlayerContent _playerContent;

        public PlayerFactory(PlayerContent playerContent, IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
            _playerContent = playerContent;
        }

        public PlayerView Create()
        {
            var go = Object.Instantiate(_playerContent.PlayerPrefab);
            _objectResolver.InjectGameObject(go);
            return go.GetComponent<PlayerView>();
        }
    }
}