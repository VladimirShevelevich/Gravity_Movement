using UnityEngine;

namespace App.Platform
{
    public class PlatformView : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _collider;

        public Bounds GetBounds()
        {
            return _collider.bounds;
        }
    }
}