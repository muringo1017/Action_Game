using UnityEngine;

public abstract class BasePlayerState : IPlayerState
{
    protected Player _player;
    protected PlayerStateMachine _stateMachine;
    protected PlayerController _controller;
    protected PlayerCombat _combat;
    protected CharacterAnimation _characterAnimation;
    protected Rigidbody _rigidbody;

    public virtual void OnEnter(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _player = stateMachine.Player; 
        _controller = _player.Controller;
        _combat = _player.Combat;
        _characterAnimation = _player.CharacterAnimation;
        _rigidbody = _player.Rigidbody;
    }

    public abstract void OnUpdate();
    public abstract void OnExit();
    public virtual bool CanTransitionTo(PlayerState newState) => true;
}