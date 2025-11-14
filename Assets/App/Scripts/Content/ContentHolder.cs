using UnityEngine;
using VContainer;

namespace App.ContentHolder
{
    [CreateAssetMenu(fileName = "ContentHolder", menuName = "Content/ContentHolder", order = 0)]
    public class ContentHolder : ScriptableObject
    {
        [SerializeField] private Content[] _contents;
        
        public void Register(IContainerBuilder builder)
        {
            foreach (var content in _contents)
            {
                builder.RegisterInstance(content).As(content.GetType());
            }
        }
    }
}