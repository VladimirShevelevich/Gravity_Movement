using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace App.Input
{
    public class GuiInputView : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<bool> IsRightMoveBtnPressed => _isRightMoveBtnPressed;
        private readonly ReactiveProperty<bool> _isRightMoveBtnPressed = new();
        
        public IReadOnlyReactiveProperty<bool> IsLeftMoveBtnPressed => _isLeftMoveBtnPressed;
        private readonly ReactiveProperty<bool> _isLeftMoveBtnPressed = new();
        
        public event Action OnJumpBtnClicked;
        
        [SerializeField] private Button _leftMoveButton;
        [SerializeField] private Button _rightMoveButton;
        [SerializeField] private Button _jumpButton;

        private void Start()
        {
            SubscribeOnButtons();
        }

        private void SubscribeOnButtons()
        {
            _jumpButton.onClick.AddListener(() => 
                OnJumpBtnClicked?.Invoke());

            _rightMoveButton.OnPointerDownAsObservable().Subscribe(_ => 
                _isRightMoveBtnPressed.Value = true);
            _rightMoveButton.OnPointerUpAsObservable().Subscribe(_ => 
                _isRightMoveBtnPressed.Value = false);
            _leftMoveButton.OnPointerDownAsObservable().Subscribe(_ => 
                _isLeftMoveBtnPressed.Value = true);
            _leftMoveButton.OnPointerUpAsObservable().Subscribe(_ => 
                _isLeftMoveBtnPressed.Value = false);
        }
    }
}