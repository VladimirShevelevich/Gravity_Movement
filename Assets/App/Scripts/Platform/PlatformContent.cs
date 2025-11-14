using App.Content;
using UnityEngine;

namespace App.Platform
{
    [CreateAssetMenu(fileName = "PlatformContent", menuName = "Content/Platform")]
    public class PlatformContent : BaseContent
    {
        [field: SerializeField] public GameObject PlatformPrefab { get; private set; }
    }
}