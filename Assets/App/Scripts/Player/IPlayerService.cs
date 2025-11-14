using UniRx;
using UnityEngine;

namespace App.Player
{
    public interface IPlayerService
    {
        IReadOnlyReactiveProperty<Vector3> PlayerPosition { get; }
    }
}