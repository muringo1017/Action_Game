using UnityEngine;

public class IdleState : BasePlayerState
{
    public override void OnEnter(PlayerStateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        Debug.Log("Entered Idle State");
        
        // 애니메이션 설정
        _characterAnimation?.SetMoving(false);
    }

    public override void OnUpdate()
    {
        if (_player == null) return;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            _stateMachine.TransitionTo(PlayerState.Move);
            return;
        }

        // 공격 입력 감지
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            _stateMachine.TransitionTo(PlayerState.Attack);
            return;
        }

        // 무기 교체 (PlayerManager 통해 접근)
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Managers.WeaponManager 사용
            // stateMachine.TransitionTo(PlayerState.SwitchWeapon);
        }
    }

    public override void OnExit()
    {
        Debug.Log("Exited Idle State");
    }

    // 특정 상태로 전환 가능한지 확인
    public override bool CanTransitionTo(PlayerState newState)
    {
        // Idle 상태에서는 대부분의 상태로 전환 가능
        return newState != PlayerState.Idle;
    }
}