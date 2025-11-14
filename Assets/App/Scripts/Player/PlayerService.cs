using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace App.Player
{
    public class PlayerService : IInitializable
    {
        public IReadOnlyReactiveProperty<Vector3> PlayerPosition =>
            _playerView.CurrentPosition;
        
        private readonly PlayerFactory _playerFactory;
        private PlayerView _playerView;

        public PlayerService(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            _playerView = _playerFactory.Create();
        }
    }
}