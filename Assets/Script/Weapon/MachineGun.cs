using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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

    public override void Reload()
    {
        if(!canShoot||currentButtleSum ==MaxButtleSum)
        {
            return;
        }
        StartCoroutine(Reloading());
    }

    public IEnumerator Reloading()
    {
        canShoot = false;
        yield return new WaitForSeconds(ReloadTime);
        currentButtleSum = MaxButtleSum;
        canShoot = true;
    }

    public override void WeaponFire(Vector3 mousePosition)
    {
        InvokeRepeating("Shoot", 0, 1 / FireRate);
    }

    
    private void Shoot()
    {
        if(!canShoot||currentButtleSum<=0)
        {
            return;
        }
        GameObject bullet = (GameObject)Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);
        currentButtleSum--;
        Vector3 velocity = (FirePoint.position - WeaponHandle.position).normalized * currentButtleFlySpeed;
        bullet.GetComponent<Bullet>().SetDefaut(velocity,Damage,transform.parent.parent.name);

        //NetworkServer.Spawn(bullet);
    }
}
