using UnityEngine;

namespace App.Input
{
    public class GuiInputFactory
    {
        private readonly InputContent _inputContent;
        private readonly Canvas _mainCanvas;

        public GuiInputFactory(InputContent inputContent, Canvas mainCanvas)
        {
            _inputContent = inputContent;
            _mainCanvas = mainCanvas;
        }
        
        public GuiInputView Create()
        {
            return GameObject.Instantiate(_inputContent.GuiInputView, _mainCanvas.transform);
        }
    }
}