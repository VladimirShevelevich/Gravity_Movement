using App.Content;
using UnityEngine;

namespace App.Input
{
    [CreateAssetMenu(fileName = "InputContent", menuName = "Content/Input")]
    public class InputContent : BaseContent
    {
        [field: SerializeField] public GuiInputView GuiInputView { get; private set; }
    }
}