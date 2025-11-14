using UnityEngine;
using VContainer;

namespace App.Player
{
    public class PlayerGravityAdjuster : MonoBehaviour
    {
        private Quaternion _targetRotation;
        private PlayerContent _playerContent;

        [Inject]
        public void Construct(PlayerContent playerContent)
        {
            _playerContent = playerContent;
        }
        
        private void Update()
        {
            SetTargetRotation();
            Rotate();
        }

        private void Rotate()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                _targetRotation, 
                _playerContent.RotationSpeed * Time.deltaTime);
        }

        private void SetTargetRotation()
        {
            var gravity = Physics2D.gravity;
            var angle = Mathf.Atan2(gravity.y, gravity.x) * Mathf.Rad2Deg;
            angle += 90f;
            _targetRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}