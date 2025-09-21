using System;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    Idle,
    Move,
    Attack,
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
            //{ PlayerState.Reload, new ReloadState() },
            //{ PlayerState.SwitchWeapon, new SwitchWeaponState() },
            //{ PlayerState.Dead, new DeadState() }
        };
    }

    // Enum으로 상태 전환 (주로 사용)
    public void TransitionTo(PlayerState newState)
    {
        
        
        TransitionTo(_states[newState]);
    }

    // IPlayerState로 상태 전환
    public void TransitionTo(IPlayerState newState)
    {
    
        
        // 새 상태 시작
        _currentState = newState;
        _currentState.OnEnter(this);
    }

    private PlayerState GetCurrentStateType()
    {
        return GetStateType(_currentState);
    }

    private PlayerState GetStateType(IPlayerState state)
    {
        if (state == null) return PlayerState.Idle;
        
        foreach (var pair in _states)
        {
            if (pair.Value == state)
                return pair.Key;
        }
        return PlayerState.Idle;
    }

    // Helper method
    public bool IsInState(PlayerState state)
    {
        return GetStateType(_currentState) == state;
    }
}