using System;
using UniRx;
using VContainer.Unity;

namespace App.Input
{
    public class KeyboardInputHandler : IInputHandler, ITickable
    {
        public IReadOnlyReactiveProperty<float> HorizontalInput => _horizontalInput;
        private readonly ReactiveProperty<float> _horizontalInput = new();
        
        public event Action OnJumpInput;

        public void Tick()
        {
            UpdateAxeInput();
            CheckJumpInput();
        }

        private void UpdateAxeInput()
        {
            _horizontalInput.Value = UnityEngine.Input.GetAxisRaw("Horizontal");
        }

        private void CheckJumpInput()
        {
            if (UnityEngine.Input.GetButtonDown("Jump"))
                OnJumpInput?.Invoke();
        }
    }
}