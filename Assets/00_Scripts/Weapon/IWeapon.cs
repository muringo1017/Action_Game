using UnityEngine;

public enum WeaponType
{
    None,
    Melee,
    Ranged
}

public interface IWeapon
{
    WeaponType GetWeaponType();
    string GetWeaponName();
    void PerformLightAttack(PlayerCombat combat);
    void PerformHeavyAttack(PlayerCombat combat);
    void OnEquip(PlayerCombat combat);
    void OnUnequip(PlayerCombat combat);
    GameObject GetWeaponPrefab();
}