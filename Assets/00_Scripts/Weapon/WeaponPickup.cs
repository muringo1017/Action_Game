using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private string specificWeaponName;

    public IWeapon GetWeapon()
    {
        Debug.Log($"Trying to get weapon: {weaponType} - {specificWeaponName}");
        
        switch (weaponType)
        {
            case WeaponType.Melee:
                return specificWeaponName switch
                {
                    "ShortSword" => new ShortSword(),
                    "LongSword" => new LongSword(),
                    _ => new ShortSword()
                };

            case WeaponType.Ranged:
                return specificWeaponName switch
                {
                    "Pistol" => new Pistol(),
                    "AssaultRifle" => new AssaultRifle(),
                    //"Shotgun" => new Shotgun(),
                    _ => new Pistol()
                };

            default:
                return new ShortSword();
        }
    }

    // 테스트용: 인스펙터에서 바로 무기 생성 가능하게
    [ContextMenu("Test Create Weapon")]
    private void TestCreateWeapon()
    {
        IWeapon weapon = GetWeapon();
        Debug.Log($"Created weapon: {weapon.GetWeaponName()}");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}