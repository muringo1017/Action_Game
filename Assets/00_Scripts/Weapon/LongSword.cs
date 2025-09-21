using UnityEngine;

public class LongSword : BaseWeapon
{
    public LongSword()
    {
        weaponName = "LongSword";
        weaponType = WeaponType.Melee;
        // weaponPrefab = Resources.Load<GameObject>("Weapons/LongSword");
    }

    public override void PerformLightAttack(PlayerCombat combat)
    {
        //combat.CharacterAnimation.LongSwordLightAttack();
    }

    public override void PerformHeavyAttack(PlayerCombat combat)
    {
        //combat.CharacterAnimation.LongSwordHeavyAttack();
    }
}