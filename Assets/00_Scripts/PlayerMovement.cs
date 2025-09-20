using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    
    private Rigidbody _rigidbody;
    private float _rotationY = 90f;
    
    private float _moveSpeed = 4f;
    private float _scrollSpeed = 1.5f;
    private float _rotationSpeed = 15f;

    private void Awake()
    {
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        _rigidbody = GetComponent<Rigidbody>();
        
        
    }

    private void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    private void FixedUpdate()
    {
        
        DetectMovement();
    }

    void DetectMovement()
    {
        _rigidbody.linearVelocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * _moveSpeed,
            _rigidbody.linearVelocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * _scrollSpeed);
    }

    void RotatePlayer()
    {
        
        
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(_rotationY), 0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(_rotationY), 0f);
        }
    } // rotate logic

    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 ||
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            _playerAnimation.Walk(true);
        }
        else
        {
            _playerAnimation.Walk(false);
        }
    } // walk animation 

    void AnimatePlayerPunch()
    {
        
    }
}
