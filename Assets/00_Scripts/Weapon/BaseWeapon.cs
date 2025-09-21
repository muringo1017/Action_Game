using UnityEngine;

public abstract class BaseWeapon : IWeapon
{
    protected string weaponName;
    protected GameObject weaponPrefab;
    protected WeaponType weaponType;

    public abstract void PerformLightAttack(PlayerCombat combat);
    public abstract void PerformHeavyAttack(PlayerCombat combat);
    
    public virtual void OnEquip(PlayerCombat combat)
    {
       // combat.CharacterAnimation.ResetCombo();
        // 무기 모델 장착 로직
    }

    public virtual void OnUnequip(PlayerCombat combat)
    {
        //combat.CharacterAnimation.ResetCombo();
        // 무기 모델 해제 로직
    }

    public WeaponType GetWeaponType() => weaponType;
    public string GetWeaponName() => weaponName;
    public GameObject GetWeaponPrefab() => weaponPrefab;
}