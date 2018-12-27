using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//机关枪
public class MachineGun : Weapon {

    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float offset = 0.1f;

    public override void CancelFire()
    {
        CancelInvoke("Shoot");
    }

    public override void WeaponFire()
    {
        InvokeRepeating("Shoot", 0, 1 / FireRate);
    }

    private void Shoot()
    {
        Debug.Log("MachineGun Fire!");
        GameObject bullet = (GameObject)Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);
        Vector3 velocity = (LockPoint - FirePoint.position).normalized * currentButtleFlySpeed;

        bullet.GetComponent<Bullet>().SetVelocity(velocity);
    }
}
