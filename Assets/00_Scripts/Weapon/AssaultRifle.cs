using UnityEngine;

public class AssaultRifle : IWeapon
{
    public WeaponData Data { get; private set; }
    private bool _isFiring = false;

    public AssaultRifle(WeaponData data)
    {
        Data = data;
    }

    public void HandleInput(PlayerCombat combat, AttackType attackType, bool isInputReleased)
    {
        if (attackType == AttackType.LightAttack && !isInputReleased)
        {
            // 단발
            Debug.Log("Rifle Single Shot!");
            //combat.CharacterAnimation.RifleSingleShot();
            combat.PlayerStateMachine.TransitionTo(PlayerState.Attack);
        }
        else if (attackType == AttackType.HeavyAttack)
        {
            if (!isInputReleased && !_isFiring)
            {
                // 연사 시작
                _isFiring = true;
                Debug.Log("Rifle Auto Fire Start!");
                //combat.CharacterAnimation.RifleAutoFire(true);
            }
            else if (isInputReleased && _isFiring)
            {
                // 연사 중지
                _isFiring = false;
                Debug.Log("Rifle Auto Fire Stop!");
                //combat.CharacterAnimation.RifleAutoFire(false);
            }
        }
    }

    public void PerformAttack(CharacterAnimation characterAnim)
    {
        throw new System.NotImplementedException();
    }

    public void OnEquip(PlayerCombat combat) { Debug.Log("Assault Rifle Equipped"); }
    public void OnUnequip(PlayerCombat combat) { Debug.Log("Assault Rifle Unequipped"); }
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