using System;
using UniRx;
using UnityEngine;

namespace App.Player
{
    public class PlayerView : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<Vector3> CurrentPosition => _currentPosition;
        private readonly ReactiveProperty<Vector3> _currentPosition = new();

        private void Update()
        {
            _currentPosition.Value = transform.position;
        }
    }
}