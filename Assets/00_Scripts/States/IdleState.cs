using UnityEngine;

public class IdleState : BasePlayerState
{
    public override void OnEnter(PlayerStateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        _controller?.Stop();
        _characterAnimation?.SetMoving(false);
    }

    public override void OnUpdate()
    {
        if (_player == null) return;
        
        // 공격 입력 확인 로직 제거 (StateMachine이 이벤트로 처리)
        float horizontal = Managers.InputManager.MoveInput.x;
        if (horizontal != 0)
        {
            _stateMachine.TransitionTo(PlayerState.Move);
        }
    }

    public override void OnExit() { }
}