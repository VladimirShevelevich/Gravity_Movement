using UnityEngine;

namespace App.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetRun(bool run)
        {
            _animator.SetBool("Run", run);
        }
    }
}