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
        Move();
    }    
    
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveInput * _playerContent.Speed, _rb.velocity.y);
    }

    private void Move()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
            _rb.velocity = new Vector2(_rb.velocity.x, _playerContent.JumpForce);

        if (_moveInput > 0 && !_isFacingRight)
            Flip();
        else if (_moveInput < 0 && _isFacingRight)
            Flip();
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
