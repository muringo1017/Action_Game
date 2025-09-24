using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine _stateMachine;
    private PlayerController _controller;
    private PlayerCombat _combat;
    private CharacterAnimation _characterAnimation;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    
    public PlayerStateMachine StateMachine => _stateMachine;
    public PlayerController Controller => _controller;
    public PlayerCombat Combat => _combat;
    public CharacterAnimation CharacterAnimation => _characterAnimation;
    
    public Rigidbody Rigidbody => _rigidbody;
    public CapsuleCollider CapsuleCollider => _capsuleCollider;

    private void Awake()
    {
        InitalizeComponents();
    }

    private void Start()
    {
        _stateMachine?.TransitionTo(PlayerState.Idle);
    }

    private void InitalizeComponents()
    {
        
        _stateMachine = GetComponent<PlayerStateMachine>();
        _controller = GetComponent<PlayerController>();
        _combat = GetComponent<PlayerCombat>();
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();

        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    
}