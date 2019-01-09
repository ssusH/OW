using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerEquip))]
public class PlayerAttack : NetworkBehaviour {

    private PlayerEquip playerEquip;
    private GameObject WeaponPrefab;


    private Weapon weapon;

    bool FireButtonDown = false;
    bool FireButtonUp = false;

    
    public void SetCurrentWeapon(Weapon _weapon)
    {
        weapon = _weapon;
    }

    public Weapon GetCurrentWeapon()
    {

        return weapon;
    }



    // Update is called once per frame
    void Update () {

        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3( Input.mousePosition.x,Input.mousePosition.y));

        weapon.LockEnemy(mousePosition);
        

        if (Input.GetButtonDown("Fire1"))
        {
            BeginShoot(mousePosition);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            CancleShoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }

    }


    [Client]
    void BeginShoot(Vector3 mousePosition)
    {
        CmdOnBeginShoot(mousePosition);
    }


    [Command]
    void CmdOnBeginShoot(Vector3 mousePosition)
    {
        RpcBeginShoot(mousePosition);
    }

    [ClientRpc]
    void RpcBeginShoot(Vector3 mousePosition)
    {
        weapon.WeaponFire(mousePosition);
    }



    [Client]
    void CancleShoot()
    {
        CmdOnCancleShoot();
    }


    [Command]
    void CmdOnCancleShoot()
    {
        RpcCancleShoot();
    }

    [ClientRpc]
    void RpcCancleShoot()
    {
        weapon.CancelFire();
    }

}
