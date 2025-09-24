using UnityEngine;

public class EquipState : BasePlayerState
{
    private float _equipTimer;
    private const float EQUIP_ANIMATION_DURATION = 0.7f; // 장착/해제 애니메이션 길이

    public override void OnEnter(PlayerStateMachine stateMachine)
    {
        base.OnEnter(stateMachine);

        // PlayerCombat의 무기 상호작용 로직 호출
        _player.Combat.HandleWeaponInteraction();
        
        // 타이머 설정
        _equipTimer = EQUIP_ANIMATION_DURATION;
    }

    public override void OnUpdate()
    {
        // 타이머를 감소시키고, 0이 되면 Idle 상태로 전환
        _equipTimer -= Time.deltaTime;
        if (_equipTimer <= 0f)
        {
            _stateMachine.TransitionTo(PlayerState.Idle);
        }
    }
    
    public override void OnExit() { }
}