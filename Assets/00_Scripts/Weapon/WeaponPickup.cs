using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    private IWeapon _weaponInstance;

    private void Awake()
    {
        // WeaponData를 기반으로 실제 무기 인스턴스를 생성
        // 이 부분은 나중에 무기 종류가 많아지면 팩토리 패턴으로 개선할 수 있습니다.
        if (weaponData.weaponName == "LongSword")
        {
            _weaponInstance = new LongSword(weaponData);
        }
        else if (weaponData.weaponName == "Pistol")
        {
            _weaponInstance = new Pistol(weaponData);
        }
    }

    public IWeapon GetWeapon()
    {
        return _weaponInstance;
    }
}