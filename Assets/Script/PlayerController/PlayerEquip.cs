using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerEquip : MonoBehaviour {

    private Weapon CurrentWeapon;
    private PlayerState playerState;


    [SerializeField]
    private GameObject WeaponPrefab;
    [SerializeField]
    private Transform WeaponHandle;
    private GameObject WeaponInstance;

    private PlayerAttack playerAttack;

    private void Start()
    {
        playerState = GetComponent<PlayerState>();
        playerAttack = GetComponent<PlayerAttack>();
        EquipWeapon();
    }
    
    public void EquipWeapon()
    {
        WeaponInstance = (GameObject)Instantiate(WeaponPrefab, WeaponHandle);
        CurrentWeapon = WeaponInstance.GetComponent<Weapon>();
        CurrentWeapon.SetWeaponHandle(WeaponHandle);
        CurrentWeapon.SetButtleFlySpeed(playerState.GetBulletFlySpeedPercent());
        playerAttack.SetCurrentWeapon(CurrentWeapon);
    }

    
}
