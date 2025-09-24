using UnityEngine;

public class AttackState : BasePlayerState
{
    private float _attackTimer;
    private float _attackDuration = 0.7f; // 공격 애니메이션 평균 길이 (조정 필요)

    public override void OnEnter(PlayerStateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        _player.Combat.PerformCurrentAttack();
        _attackTimer = _attackDuration; // 타이머 설정
    }
    
    public override void OnUpdate()
    {
        // 타이머를 감소시키고, 0이 되면 Idle 상태로 전환
        _attackTimer -= Time.deltaTime;
        if (_attackTimer <= 0f)
        {
            _stateMachine.TransitionTo(PlayerState.Idle);
        }
    }
    
    public override void OnExit() { }
}