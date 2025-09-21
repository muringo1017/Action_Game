using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private PlayerCombat _combat;
    [SerializeField] private CharacterAnimation _characterAnimation;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    // Public properties for easy access
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