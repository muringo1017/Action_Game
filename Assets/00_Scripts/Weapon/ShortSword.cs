using UnityEngine;

public class ShortSword : BaseWeapon
{
    public ShortSword()
    {
        weaponName = "Short Sword";
        weaponType = WeaponType.Melee;
    }

    public override void PerformLightAttack(PlayerCombat combat)
    {
        Debug.Log("Short Sword Light Attack! (Z pressed)");
       // combat.CharacterAnimation.ShortSwordLightAttack();
    }

    public override void PerformHeavyAttack(PlayerCombat combat)
    {
        Debug.Log("Short Sword Heavy Attack! (X pressed)");
        //combat.CharacterAnimation.ShortSwordHeavyAttack();
    }
}

