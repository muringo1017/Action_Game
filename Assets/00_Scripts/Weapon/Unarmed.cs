using UnityEngine;

public class Unarmed : IWeapon
{
    public WeaponData Data { get; private set; }

    // Unarmed 상태의 고유 콤보 로직
    private ComboState _currentComboState = ComboState.NONE;
    private float _comboResetTimer;
    private const float COMBO_RESET_TIME = 1.0f;

    public Unarmed(WeaponData data)
    {
        Data = data;
    }
    
    public void HandleInput(PlayerCombat combat, AttackType attackType, bool isInputReleased)
    {
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
        switch (_currentComboState)
        {
            case ComboState.NONE:
                if (attackType == AttackType.LightAttack) nextState = ComboState.LightAttack_1;
                else if (attackType == AttackType.HeavyAttack) nextState = ComboState.HeavyAttack_1;
                break;
            
            case ComboState.LightAttack_1:
                if (attackType == AttackType.LightAttack) nextState = ComboState.LightAttack_2;
                else if (attackType == AttackType.HeavyAttack) nextState = ComboState.HeavyAttack_1;
                break;

            case ComboState.LightAttack_2:
                if (attackType == AttackType.LightAttack) nextState = ComboState.LightAttack_3;
                else if (attackType == AttackType.HeavyAttack) nextState = ComboState.HeavyAttack_2;
                break;

            case ComboState.HeavyAttack_1:
                if (attackType == AttackType.HeavyAttack) nextState = ComboState.HeavyAttack_2;
                break;
        }

        if (nextState != _currentComboState)
        {
            _currentComboState = nextState;
            combat.PlayerStateMachine.TransitionTo(PlayerState.Attack);
            _comboResetTimer = COMBO_RESET_TIME;
        }
    }
    
    public void PerformAttack(CharacterAnimation characterAnim)
    {
        switch (_currentComboState)
        {
            case ComboState.LightAttack_1: characterAnim.LightAttack_1(); break;
            case ComboState.LightAttack_2: characterAnim.LightAttack_2(); break;
            case ComboState.LightAttack_3: characterAnim.LightAttack_3(); break;
            case ComboState.HeavyAttack_1: characterAnim.HeavyAttack_1(); break;
            case ComboState.HeavyAttack_2: characterAnim.HeavyAttack_2(); break;
            case ComboState.HeavyAttack_3: characterAnim.HeavyAttack_3(); break;
        }
    }

    public void OnEquip(PlayerCombat combat) { /* 맨손은 특별한 로직 없음 */ }
    public void OnUnequip(PlayerCombat combat) { /* 맨손은 특별한 로직 없음 */ }
}