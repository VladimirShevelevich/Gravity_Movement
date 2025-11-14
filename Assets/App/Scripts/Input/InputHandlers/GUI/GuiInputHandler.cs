using System;
using UniRx;
using VContainer.Unity;

namespace App.Input
{
    public class GuiInputHandler : IInputHandler, IInitializable
    {
        public IReadOnlyReactiveProperty<float> HorizontalInput => _horizontalInput;
        private readonly ReactiveProperty<float> _horizontalInput = new();
        
        public event Action OnJumpInput;
        
        private readonly GuiInputFactory _guiInputFactory;
        private GuiInputView _guiInputView;

        public GuiInputHandler(GuiInputFactory guiInputFactory)
        {
            _guiInputFactory = guiInputFactory;
        }

        public void Initialize()
        {
            CreateView();
        }

        private void CreateView()
        {
            _guiInputView = _guiInputFactory.Create();
            _guiInputView.OnJumpBtnClicked += () =>
                OnJumpInput?.Invoke();

            _guiInputView.IsRightMoveBtnPressed.Merge(_guiInputView.IsLeftMoveBtnPressed).Subscribe(_ =>
                OnButtonsStateChanged());
        }

        private void OnButtonsStateChanged()
        {
            if (_guiInputView.IsRightMoveBtnPressed.Value)
                _horizontalInput.Value = 1;
            else if (_guiInputView.IsLeftMoveBtnPressed.Value)
                _horizontalInput.Value = -1;
            else 
                _horizontalInput.Value = 0;

        }
    }
}