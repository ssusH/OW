using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEquip))]
public class PlayerAttack : MonoBehaviour {

    private PlayerEquip playerEquip;
    private GameObject WeaponPrefab;
    private Weapon weapon;

    bool FireButtonDown = false;
    bool FireButtonUp = false;

    // Use this for initialization
    void Start () {
        playerEquip = GetComponent<PlayerEquip>();
        
        weapon = playerEquip.GetCurrentWeapon();
    }
	
	// Update is called once per frame
	void Update () {

        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3( Input.mousePosition.x,Input.mousePosition.y));

        weapon.LockEnemy(mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.WeaponFire();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            weapon.CancelFire();
        }

        
    }

    
}
