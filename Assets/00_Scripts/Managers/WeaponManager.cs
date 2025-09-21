using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    private IWeapon currentWeapon;
    private PlayerCombat playerCombat;
    private bool isSwitchingWeapon = false;

    public IWeapon CurrentWeapon => currentWeapon;
    public bool HasWeapon => currentWeapon != null;
    public bool IsSwitchingWeapon => isSwitchingWeapon;

    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
    }

    public bool PickupWeapon(IWeapon newWeapon)
    {
        if (isSwitchingWeapon) return false;

        StartCoroutine(SwitchWeaponCoroutine(newWeapon));
        return true;
    }

    private IEnumerator SwitchWeaponCoroutine(IWeapon newWeapon)
    {
        isSwitchingWeapon = true;

        // 기존 무기 있으면 내려놓기
        if (currentWeapon != null)
        {
            currentWeapon.OnUnequip(playerCombat);
            yield return new WaitForSeconds(0.5f);
        }

        // 새 무기 장착
        currentWeapon = newWeapon;
        currentWeapon.OnEquip(playerCombat);
        yield return new WaitForSeconds(0.5f);

        isSwitchingWeapon = false;
        Debug.Log($"Equipped: {currentWeapon.GetWeaponName()}");
    }

    public void DropCurrentWeapon()
    {
        if (currentWeapon != null && !isSwitchingWeapon)
        {
            StartCoroutine(DropWeaponCoroutine());
        }
    }

    private IEnumerator DropWeaponCoroutine()
    {
        isSwitchingWeapon = true;

        currentWeapon.OnUnequip(playerCombat);
        yield return new WaitForSeconds(0.5f);

        // 무기 오브젝트 생성 (필드에 드롭)
        // GameObject droppedWeapon = Instantiate(currentWeapon.GetWeaponPrefab(), transform.position, Quaternion.identity);

        Debug.Log($"Dropped: {currentWeapon.GetWeaponName()}");
        currentWeapon = null;
        isSwitchingWeapon = false;
    }

    public void PerformLightAttack()
    {
        if (currentWeapon != null && !isSwitchingWeapon)
        {
            currentWeapon.PerformLightAttack(playerCombat);
        }
    }

    public void PerformHeavyAttack()
    {
        if (currentWeapon != null && !isSwitchingWeapon)
        {
            currentWeapon.PerformHeavyAttack(playerCombat);
        }
    }

    public void ReloadCurrentWeapon()
    {
        if (currentWeapon != null && !isSwitchingWeapon)
        {
           // currentWeapon.Reload();
        }
    }
}