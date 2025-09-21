using UnityEngine;

public class AttackState : BasePlayerState
{
    private float attackDuration = 0.5f;
    private float attackTimer;

    public override void OnEnter(PlayerStateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        Debug.Log("Entered Attack State");
        attackTimer = attackDuration;

        // 공격 실행
        if (Input.GetKeyDown(KeyCode.Z))
            _combat.PerformDefaultLightAttack();
        else if (Input.GetKeyDown(KeyCode.X))
            _combat.PerformDefaultHeavyAttack();
    }

    public override void OnUpdate()
    {
        attackTimer -= Time.deltaTime;

        // 공격 종료 후 idle로 전환
        if (attackTimer <= 0f)
        {
            _stateMachine.TransitionTo(PlayerState.Idle);
        }
    }

    public override void OnExit()
    {
        Debug.Log("Exited Attack State");
    }

    public override bool CanTransitionTo(PlayerState newState)
    {
        // 공격 중에는 특정 상태로만 전환 가능
        return newState == PlayerState.Idle || newState == PlayerState.Dead;
    }
}