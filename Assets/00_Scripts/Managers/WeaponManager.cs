using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponHand; 
    
    public IWeapon CurrentWeapon { get; private set; }
    public bool HasWeapon => CurrentWeapon != null;
    public bool IsSwitchingWeapon { get; private set; }
    
    private GameObject _equippedWeaponObject;
    private PlayerCombat _playerCombat;

    private void Awake()
    {
        _playerCombat = GetComponent<PlayerCombat>();
    }

    // [수정] 이제 WeaponPickup 컴포넌트 자체를 받습니다.
    public void EquipWeapon(WeaponPickup weaponPickup)
    {
        if (IsSwitchingWeapon) return;
        StartCoroutine(SwitchWeaponCoroutine(weaponPickup));
    }

    private IEnumerator SwitchWeaponCoroutine(WeaponPickup newWeaponPickup)
    {
        IsSwitchingWeapon = true;
        
        // 기존 무기가 있으면 먼저 내려놓습니다.
        if (CurrentWeapon != null)
        {
            DropCurrentWeapon();
            yield return new WaitForSeconds(0.5f); // 내려놓는 애니메이션 시간
        }

        // 새로운 무기(논리)를 가져옵니다.
        CurrentWeapon = newWeaponPickup.GetWeapon();
        
        // 새로운 무기(오브젝트)를 가져와 손으로 옮깁니다.
        _equippedWeaponObject = newWeaponPickup.gameObject;
        
        // 1. 부모를 weaponHand로 설정하고 위치를 초기화합니다.
        _equippedWeaponObject.transform.SetParent(weaponHand);
        _equippedWeaponObject.transform.localPosition = Vector3.zero;
        _equippedWeaponObject.transform.localRotation = Quaternion.identity;

        // 2. 물리적 충돌 및 상호작용을 막기 위해 Collider와 스크립트를 비활성화합니다.
        if (_equippedWeaponObject.TryGetComponent<Collider>(out var collider))
        {
            collider.enabled = false;
        }
        newWeaponPickup.enabled = false;

        CurrentWeapon.OnEquip(_playerCombat);
        yield return new WaitForSeconds(0.5f); // 줍는 애니메이션 시간

        IsSwitchingWeapon = false;
    }

    public void DropCurrentWeapon()
    {
        if (CurrentWeapon == null || IsSwitchingWeapon) return;

        // 1. 부모 연결을 해제하여 월드에 독립적으로 만듭니다.
        _equippedWeaponObject.transform.SetParent(null);
        // (선택) 플레이어의 발밑 등 특정 위치에 생성되도록 위치 조정
        // _equippedWeaponObject.transform.position = _playerCombat.transform.position;
        
        // 2. 다시 주울 수 있도록 Collider와 스크립트를 활성화합니다.
        if (_equippedWeaponObject.TryGetComponent<Collider>(out var collider))
        {
            collider.enabled = true;
        }
        _equippedWeaponObject.GetComponent<WeaponPickup>().enabled = true;

        CurrentWeapon.OnUnequip(_playerCombat);
        
        // 참조를 초기화합니다.
        CurrentWeapon = null;
        _equippedWeaponObject = null;
    }
}