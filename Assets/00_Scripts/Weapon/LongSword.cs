using UnityEngine;

public class LongSword : IWeapon
{
    public WeaponData Data { get; private set; }

    // LongSword만의 고유 콤보 상태
    private ComboState _currentComboState = ComboState.NONE;
    private float _comboResetTimer;
    private const float COMBO_RESET_TIME = 1.2f; // 장검은 약간 더 긴 콤보 시간을 가질 수 있습니다.

    public LongSword(WeaponData data)
    {
        Data = data;
    }
    
    public void HandleInput(PlayerCombat combat, AttackType attackType, bool isInputReleased)
    {
        // 매 프레임 호출되며 콤보 타이머를 업데이트합니다.
        if (_currentComboState != ComboState.NONE)
        {
            _comboResetTimer -= Time.deltaTime;
            if (_comboResetTimer <= 0)
            {
                _currentComboState = ComboState.NONE;
            }
        }
        
        if (attackType == AttackType.None || isInputReleased) return;

        var nextState = _currentComboState;
        // --- LongSword만의 다른 콤보 트리 ---
        switch (_currentComboState)
        {
            case ComboState.NONE:
                if (attackType == AttackType.LightAttack) nextState = ComboState.LightAttack_1;
                // 장검은 강공격으로 콤보를 시작할 수 있습니다.
                else if (attackType == AttackType.HeavyAttack) nextState = ComboState.HeavyAttack_1; 
                break;
            case ComboState.LightAttack_1:
                if (attackType == AttackType.LightAttack) nextState = ComboState.LightAttack_2;
                // Z -> X 콤보
                else if (attackType == AttackType.HeavyAttack) nextState = ComboState.HeavyAttack_2;
                break;
            case ComboState.LightAttack_2:
                if (attackType == AttackType.LightAttack) nextState = ComboState.LightAttack_3;
                break;
            case ComboState.HeavyAttack_1:
                // X -> X 콤보
                if (attackType == AttackType.HeavyAttack) nextState = ComboState.HeavyAttack_2;
                break;
        }

        if (nextState != _currentComboState)
        {
            _currentComboState = nextState;
            // PlayerCombat을 통해 상태 머신에 상태 전환을 요청합니다.
            combat.PlayerStateMachine.TransitionTo(PlayerState.Attack);
            _comboResetTimer = COMBO_RESET_TIME;
        }
    }

    /// <summary>
    /// AttackState에 진입했을 때 호출되어 실제 LongSword 애니메이션을 재생합니다.
    /// </summary>
    public void PerformAttack(CharacterAnimation characterAnim)
    {
        // 각 콤보 상태에 맞는 'LongSword' 전용 애니메이션 함수를 호출합니다.
        switch (_currentComboState)
        {
            case ComboState.LightAttack_1: characterAnim.LongSword_Light_1(); break;
            case ComboState.LightAttack_2: characterAnim.LongSword_Light_2(); break;
            case ComboState.LightAttack_3: characterAnim.LongSword_Light_3(); break;
            case ComboState.HeavyAttack_1: characterAnim.LongSword_Heavy_1(); break;
            case ComboState.HeavyAttack_2: characterAnim.LongSword_Heavy_2(); break;
        }
    }

    public void OnEquip(PlayerCombat combat)
    {
        Debug.Log("LongSword Equipped");
        // 여기에 장검을 장착했을 때 모델의 손에 칼을 보이게 하는 로직 등을 추가할 수 있습니다.
    }

    public void OnUnequip(PlayerCombat combat)
    {
        Debug.Log("LongSword Unequipped");
        // 장착 해제 시 칼을 보이지 않게 하는 로직 등을 추가할 수 있습니다.
    }

    public ComboState BufferedAttack { get; }
    public void CommitToBufferedAttack()
    {
        throw new System.NotImplementedException();
    }

    public void ClearBufferedAttack()
    {
        throw new System.NotImplementedException();
    }
}