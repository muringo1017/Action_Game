using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6f;
    
    private Rigidbody _rigidbody;
    private bool _facingRight = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float horizontalInput)
    {
        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.x = horizontalInput * moveSpeed;
        _rigidbody.linearVelocity = velocity;

        if (horizontalInput > 0 && !_facingRight) Flip();
        else if (horizontalInput < 0 && _facingRight) Flip();
    }
    
    public void Stop()
    {
        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.x = 0;
        _rigidbody.linearVelocity = velocity;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}