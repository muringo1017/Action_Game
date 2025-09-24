using UnityEngine;


public enum ComboState
{
    NONE,
    LightAttack_1, // Z
    LightAttack_2, // ZZ
    LightAttack_3, // ZZZ
    HeavyAttack_1, // X 또는 Z-X
    HeavyAttack_2, // XX 또는 ZZ-X
    HeavyAttack_3  // XXX
}

[RequireComponent(typeof(WeaponManager))]
[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerCombat : MonoBehaviour
{
    // --- 컴포넌트 참조 ---
    private WeaponManager _weaponManager;
    private CharacterAnimation _characterAnimation;
    private PlayerStateMachine _stateMachine;

    public PlayerStateMachine PlayerStateMachine => _stateMachine;

    // --- 외부 데이터 참조 ---
    [SerializeField] private WeaponData unarmedWeaponData; // 맨손용 WeaponData를 인스펙터에서 할당

    // --- 전략 패턴 ---
    private IWeapon _unarmed; // 맨손(Unarmed) 상태일 때의 공격 전략

    // --- 무기 상호작용 ---
    public float pickupRange = 1.5f;

    private void Awake()
    {
        // 컴포넌트 초기화
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
        _stateMachine = GetComponent<PlayerStateMachine>();
        _weaponManager = GetComponent<WeaponManager>();

        _unarmed = new Unarmed(unarmedWeaponData);
    }

    private void Update()
    {
        if (_weaponManager.HasWeapon)
            _weaponManager.CurrentWeapon.HandleInput(this, AttackType.None, false);
        else
            _unarmed.HandleInput(this, AttackType.None, false);
    }

    public void RequestAttack(AttackType attackType, bool isInputReleased)
    {
        if (_weaponManager.HasWeapon)
        {
            _weaponManager.CurrentWeapon.HandleInput(this, attackType, isInputReleased);
        }
        else
        {
            _unarmed.HandleInput(this, attackType, isInputReleased);
        }
    }

    public void PerformCurrentAttack()
    {
        if (_weaponManager.HasWeapon)
            _weaponManager.CurrentWeapon.PerformAttack(_characterAnimation);
        else
            _unarmed.PerformAttack(_characterAnimation);
    }

    public void HandleWeaponInteraction()
    {
        if (_weaponManager.HasWeapon)
            _weaponManager.DropCurrentWeapon();
        else
            TryToPickupWeapon();
    }

    private void TryToPickupWeapon()
{
    Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange);
    foreach (var collider in colliders)
    {
        if (collider.TryGetComponent<WeaponPickup>(out var weaponPickup))
        {
            // [수정] weaponPickup 컴포넌트 자체를 넘겨주고, 더 이상 여기서 Destroy하지 않습니다.
            _weaponManager.EquipWeapon(weaponPickup);
            return; 
        }
    }
}
    public IWeapon GetCurrentWeaponStrategy()
    {
        if (_weaponManager.HasWeapon)
        {
            return _weaponManager.CurrentWeapon;
        }
        else
        {
            return _unarmed;
        }
    }
}