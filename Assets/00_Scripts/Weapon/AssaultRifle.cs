using UnityEngine;

public class AssaultRifle : BaseWeapon
{
    private int ammo = 30;
    private const int maxAmmo = 30;
    private bool isFiring = false;

    public AssaultRifle()
    {
        weaponName = "Assault Rifle";
        weaponType = WeaponType.Ranged;
        // weaponPrefab = Resources.Load<GameObject>("Weapons/AssaultRifle");
    }

    public override void PerformLightAttack(PlayerCombat combat)
    {
        if (ammo > 0 && !isFiring)
        {
            //combat.CharacterAnimation.RifleSingleShot();
            ammo--;
            // 발사체 생성 로직
        }
    }

    public override void PerformHeavyAttack(PlayerCombat combat)
    {
        if (ammo > 0)
        {
            isFiring = true;
            //combat.CharacterAnimation.RifleAutoFire();
            // 연사 로직 (코루틴 등으로 구현)
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    public void Reload()
    {
        ammo = maxAmmo;
    }
}