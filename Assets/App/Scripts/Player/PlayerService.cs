using VContainer.Unity;

namespace App.Player
{
    public class PlayerService : IInitializable
    {
        private readonly PlayerFactory _playerFactory;

        public PlayerService(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            _playerFactory.Create();
        }
    }
}