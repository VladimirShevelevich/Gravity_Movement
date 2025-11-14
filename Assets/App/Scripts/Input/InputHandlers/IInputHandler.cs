using System;
using UniRx;

namespace App.Input
{
    public interface IInputHandler
    {
        IReadOnlyReactiveProperty<float> HorizontalInput { get; }
        event Action OnJumpInput;
    }
}