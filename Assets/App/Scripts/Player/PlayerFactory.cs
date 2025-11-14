using UnityEngine;
using VContainer.Unity;

namespace App.Player
{
    public class PlayerFactory : IInitializable
    {
        private readonly PlayerContent _playerContent;

        public PlayerFactory(PlayerContent playerContent)
        {
            _playerContent = playerContent;
        }
        
        public void Initialize()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            Object.Instantiate(_playerContent.PlayerPrefab);
        }
    }
}