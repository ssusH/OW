using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Weapon : NetworkBehaviour {

    [SerializeField]
    protected float Damage = 10f; //伤害
    [SerializeField]
    protected float FireRate = 1; //开火率
    [SerializeField]
    protected float MaxAngle = 85; //射击角度

    [SerializeField]
    protected float ButtleFlySpeed = 30f;

    protected float currentButtleFlySpeed = 30f;

    [SerializeField]
    protected Transform FirePoint;

    protected Transform WeaponHandle;

    
  

    public void SetButtleFlySpeed(float Rate)
    {
        currentButtleFlySpeed = ButtleFlySpeed * Rate;
    }


    public void SetWeaponDamage(float Rate)
    {
        Damage = Damage * Rate;
    }

    public void SetWeaponHandle(Transform weaponHandle)
    {
        WeaponHandle = weaponHandle;
    }

    public void LockEnemy(Vector3 position)
    {
        float _x = position.x - WeaponHandle.position.x;
        float yangle = _x < 0 ? 180 : 0;
        _x = Mathf.Abs( _x);
        float _y = position.y - WeaponHandle.position.y;
        float angle = Mathf.Atan2(_y, _x) * Mathf.Rad2Deg;
        WeaponHandle.localEulerAngles = new Vector3(0, yangle, angle);

    }


    public abstract void WeaponFire(Vector3 mousePosition);

    public abstract void CancelFire();
}
