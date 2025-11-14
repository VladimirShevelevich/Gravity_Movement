using App.Content;
using UnityEngine;

namespace App.Gravity
{
    [CreateAssetMenu(fileName = "GravityContent", menuName = "Content/Gravity")]
    public class GravityContent : BaseContent
    {
        [field: SerializeField] public float Gravity { get; private set;}
    }
}