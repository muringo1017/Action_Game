using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
public string weaponName;

public WeaponType weaponType;

public GameObject weaponPickupPrefab; // 필드에 드랍될 때 생성될 프리팹

}