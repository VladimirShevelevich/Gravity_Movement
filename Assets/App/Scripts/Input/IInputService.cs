using System;
using UniRx;

namespace App.Input
{
    public interface IInputService
    {
        IReadOnlyReactiveProperty<float> HorizontalInput { get; }
        event Action OnJumpInput;
    }
}