using System;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Move,
    Attack,
    Equip,
    Reload,
    SwitchWeapon,
    Dead
}

public class PlayerStateMachine : MonoBehaviour
{
    private Player _player;
    private Dictionary<PlayerState, IPlayerState> _states;
    private IPlayerState _currentState;

    public Player Player => _player;
    public IPlayerState CurrentState => _currentState;
    public PlayerState CurrentStateType => GetCurrentStateType();
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        InitializeStates();
    }

    
    private void OnEnable()
    {
        if (Managers.InputManager != null)
        {
            Managers.InputManager.OnAttackPerformed += HandleAttack;
            Managers.InputManager.OnWeaponInteractPerformed += HandleWeaponInteraction; 
        }
    }

    private void OnDisable()
    {
        if (Managers.InputManager != null)
        {
            Managers.InputManager.OnAttackPerformed -= HandleAttack;
            Managers.InputManager.OnWeaponInteractPerformed -= HandleWeaponInteraction;
        }
    }

    private void Start()
    {
        TransitionTo(PlayerState.Idle);
    }

    private void Update()
    {
        _currentState?.OnUpdate();
    }

    private void InitializeStates()
    {
        _states = new Dictionary<PlayerState, IPlayerState>
        {
            { PlayerState.Idle, new IdleState() },
            { PlayerState.Move, new MoveState() },
            { PlayerState.Attack, new AttackState() },
            { PlayerState.Equip, new EquipState() } 
        };
    }

    public void TransitionTo(PlayerState newState)
    {
        _currentState?.OnExit();
        TransitionTo(_states[newState]);
    }

    public void TransitionTo(IPlayerState newState)
    {
        _currentState = newState;
        _currentState.OnEnter(this);
    }

    private PlayerState GetCurrentStateType()
    {
        foreach (var pair in _states)
        {
            if (pair.Value == _currentState)
                return pair.Key;
        }
        return PlayerState.Idle;
    }

    private void HandleAttack(AttackType attackType, bool isInputReleased)
    {
        // 공격 가능한 상태일 때만 공격을 요청
        if (CurrentStateType == PlayerState.Idle || CurrentStateType == PlayerState.Move)
        {
            _player.Combat.RequestAttack(attackType, isInputReleased);
        }
    }
    private void HandleWeaponInteraction()
    {
        // 현재 이동 또는 대기 상태일 때만 장착 상태로 전환 가능
        if (CurrentStateType == PlayerState.Idle || CurrentStateType == PlayerState.Move)
        {
            TransitionTo(PlayerState.Equip);
        }
    }
    
    
}