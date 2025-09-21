using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private WeaponManager weaponManager;
    private CharacterAnimation characterAnim;
    //private AmmoInventory ammoInventory;

    private float comboResetTime = 2f;
    private float lastAttackTime;
    private int comboCount;
    private bool isInCombo = false;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        //ammoInventory = GetComponent<AmmoInventory>();
        characterAnim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Update()
    {
        HandleCombatInput();
        CheckComboReset();
    }

    private void HandleCombatInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (weaponManager.HasWeapon)
                weaponManager.PerformLightAttack();
            else
                PerformDefaultLightAttack();
            
            comboCount++;
            lastAttackTime = Time.time;
            isInCombo = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (weaponManager.HasWeapon)
                weaponManager.PerformHeavyAttack();
            else
                PerformDefaultHeavyAttack();
            
            comboCount++;
            lastAttackTime = Time.time;
            isInCombo = true;
        }

        if (Input.GetKeyDown(KeyCode.R)) weaponManager.ReloadCurrentWeapon();
        if (Input.GetKeyDown(KeyCode.V)) HandleWeaponInteraction();
    }

    // 기본 경공격 (맨손)
    public void PerformDefaultLightAttack()
    {
        switch (comboCount % 3)
        {
            case 0:
                characterAnim.Punch1();
                break;
            case 1:
                characterAnim.Punch2();
                break;
            case 2:
                characterAnim.Punch3();
                break;
        }
    }

    // 기본 강공격 (맨손) - 추가된 함수
    public void PerformDefaultHeavyAttack()
    {
        switch (comboCount % 2)
        {
            case 0:
                characterAnim.Kick1();
                break;
            case 1:
                characterAnim.Kick2();
                break;
        }
    }

    private void CheckComboReset()
    {
        if (Time.time - lastAttackTime > comboResetTime && isInCombo)
        {
            comboCount = 0;
            isInCombo = false;
            // 콤보 리셋 애니메이션 필요시 추가
        }
    }

    private void HandleWeaponInteraction()
    {
        if (weaponManager.HasWeapon) 
            weaponManager.DropCurrentWeapon();
        else 
            TryPickupWeapon();
    }

    private void TryPickupWeapon()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f);
        foreach (var collider in colliders)
        {
            WeaponPickup weaponPickup = collider.GetComponent<WeaponPickup>();
            if (weaponPickup != null)
            {
                weaponManager.PickupWeapon(weaponPickup.GetWeapon());
                Destroy(collider.gameObject);
                break;
            }
        }
    }

    public CharacterAnimation CharacterAnimation => characterAnim;
    //public AmmoInventory AmmoInventory => ammoInventory;
}