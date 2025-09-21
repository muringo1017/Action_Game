using UnityEngine;

public class Pistol : BaseWeapon
{
    private int ammo = 12;
    private const int maxAmmo = 12;

    public Pistol()
    {
        weaponName = "Pistol";
        weaponType = WeaponType.Ranged;
        // weaponPrefab = Resources.Load<GameObject>("Weapons/Pistol");
    }

    public override void PerformLightAttack(PlayerCombat combat)
    {
        if (ammo > 0)
        {
            Debug.Log("Pistol Single Shot! (Z pressed)");
           // combat.CharacterAnimation.PistolSingleShot();
            ammo--;
            // 발사체 생성 로직
        }
        else
        {
          //  combat.CharacterAnimation.PistolDryFire();
        }
    }

    public override void PerformHeavyAttack(PlayerCombat combat)
    {
        // 권총은 연사 기능 없음 (단발만)
        PerformLightAttack(combat);
    }

    public void Reload()
    {
        ammo = maxAmmo;
    }
}

