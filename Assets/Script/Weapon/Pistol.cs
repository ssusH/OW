using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//手枪
public class Pistol : Weapon {

    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float offset = 0.1f;


    public void shoot()
    {
        Debug.Log("MachineGun Fire!");
        GameObject bullet = (GameObject)Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);
        Vector3 velocity = (LockPoint - FirePoint.position).normalized * currentButtleFlySpeed;

        bullet.GetComponent<Bullet>().SetVelocity(velocity);
    }

    public override void WeaponFire()
    {
        shoot();
    }

    public override void CancelFire()
    {
        
    }
}
