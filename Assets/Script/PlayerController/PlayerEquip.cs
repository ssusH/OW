using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerEquip : MonoBehaviour {

    private Weapon CurrentWeapon;
    private PlayerState playerState;


    [SerializeField]
    private GameObject WeaponPrefab;
    [SerializeField]
    private Transform WeaponHandle;
    private GameObject WeaponInstance;

    private void Start()
    {
        playerState = GetComponent<PlayerState>();
        EquipWeapon();
    }
    public Weapon GetCurrentWeapon()
    {
        return CurrentWeapon;
    }
	

    public void EquipWeapon()
    {
        WeaponInstance = (GameObject)Instantiate(WeaponPrefab, WeaponHandle);
        CurrentWeapon = WeaponInstance.GetComponent<Weapon>();
        CurrentWeapon.SetWeaponHandle(WeaponHandle);
        CurrentWeapon.SetButtleFlySpeed(playerState.GetBulletFlySpeedPercent());
    }

    
}
