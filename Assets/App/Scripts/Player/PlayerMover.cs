using App.Player;
using UnityEngine;
using VContainer;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    
    [Header("Ground Check")] 
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _platformLayer;

    private PlayerContent _playerContent;
    private float _moveInput;
    private bool _isFacingRight = true;

    [Inject]
    private void Construct(PlayerContent playerContent)
    {
        _playerContent = playerContent;
    }
    
    private void Update()
    {
        UpdateInput();
        CheckJump();
    }    
    
    void FixedUpdate()
    {
        ApplyVelocity();
    }

    private void ApplyVelocity()
    {
        var moveDirection = transform.right * (_moveInput * _playerContent.Speed);
        if (Physics2D.gravity.y != 0)
            _rb.velocity = new Vector2(moveDirection.x, _rb.velocity.y);
        else if (Physics2D.gravity.x != 0)
            _rb.velocity = new Vector2(_rb.velocity.x, moveDirection.y);
    }

    private void UpdateInput()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        if (_moveInput > 0 && !_isFacingRight)
            Flip();
        else if (_moveInput < 0 && _isFacingRight)
            Flip();
    }

    private void CheckJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded()) 
            _rb.velocity = new Vector2(transform.up.x, transform.up.y) * _playerContent.JumpForce;
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
