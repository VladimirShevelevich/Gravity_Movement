using App.Input;
using App.Player;
using UnityEngine;
using VContainer;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerAnimator _playerAnimator;
    
    [Header("Ground Check")] 
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _platformLayer;

    private PlayerContent _playerContent;
    private bool _isFacingRight = true;
    private IInputService _inputService;

    [Inject]
    private void Construct(PlayerContent playerContent, IInputService inputService)
    {
        _playerContent = playerContent;
        _inputService = inputService;
    }

    private void Start()
    {
        _inputService.OnJumpInput += OnJumpInput;
    }

    private void Update()
    {
        CheckDirection();
        UpdateAnimation();
    }

    private float CurrentInput => 
        _inputService.HorizontalInput.Value;

    void FixedUpdate()
    {
        ApplyVelocity();
    }

    private void ApplyVelocity()
    {
        var move = transform.right * (CurrentInput * _playerContent.Speed);
        var isVerticalGravity = Physics2D.gravity.y != 0;
        var isHorizontalGravity = Physics2D.gravity.x != 0;
        
        if (isVerticalGravity)
            _rb.velocity = new Vector2(move.x, _rb.velocity.y);
        else if (isHorizontalGravity) 
            _rb.velocity = new Vector2(_rb.velocity.x, move.y);
    }

    private void CheckDirection()
    {
        if (CurrentInput > 0 && !_isFacingRight)
            Flip();
        else if (CurrentInput < 0 && _isFacingRight)
            Flip();
    }

    private void OnJumpInput()
    {
        if (IsGrounded()) 
            _rb.velocity = new Vector2(transform.up.x, transform.up.y) * _playerContent.JumpForce;
    }

    private void UpdateAnimation()
    {
        var isRunning = CurrentInput != 0;
        _playerAnimator.SetRun(isRunning);
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _platformLayer);
    }
}
