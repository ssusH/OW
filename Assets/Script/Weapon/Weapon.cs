using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public abstract class Weapon : MonoBehaviour {

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
    protected Vector3 LockPoint;

    public void SetButtleFlySpeed(float Rate)
    {
        currentButtleFlySpeed = ButtleFlySpeed * Rate;
    }

    public void SetWeaponHandle(Transform weaponHandle)
    {
        WeaponHandle = weaponHandle;
    }

    public void LockEnemy(Vector3 position)
    {
        float _x = Mathf.Abs( position.x - WeaponHandle.position.x);
        float _y = position.y - WeaponHandle.position.y;
        float angle = Mathf.Atan2(_y, _x) * Mathf.Rad2Deg;
        WeaponHandle.localEulerAngles = new Vector3(0, 0, angle);

        SetLockPoint(new Vector3(position.x,position.y,0));
    }

    public void SetLockPoint(Vector3 position)
    {
        LockPoint = position;
    }

    public abstract void WeaponFire();
    public abstract void CancelFire();
}
