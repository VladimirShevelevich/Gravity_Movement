using App.Content;
using UnityEngine;

namespace App.Player
{
    [CreateAssetMenu(fileName = "PlayerContent", menuName = "Content/Player")]
    public class PlayerContent : BaseContent
    {
        [field: SerializeField] public GameObject PlayerPrefab { get; private set; }
    }
}