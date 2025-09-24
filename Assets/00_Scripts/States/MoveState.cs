using UnityEngine;

public class MoveState : BasePlayerState
{
    public override void OnEnter(PlayerStateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        _characterAnimation?.SetMoving(true);
    }

    public override void OnUpdate()
    {
        if (_player == null) return;
        
        float horizontal = Managers.InputManager.MoveInput.x;
        
        if (horizontal == 0)
        {
            _stateMachine.TransitionTo(PlayerState.Idle);
            return;
        }
        _controller?.Move(horizontal);
    }

    public override void OnExit()
    {
        _controller?.Stop();
        _characterAnimation?.SetMoving(false);
    }
}