using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerState : NetworkBehaviour {

    [SerializeField]
    private float MaxHealth = 200f;  //最大生命值

    [SyncVar]
    private float NowHealth = 200f;
    [SerializeField]
    private float ChargeSpeed = 1; //充能速度 百分之多少每秒
    private const float MaxEnergy = 100; //最大充能值
    [SerializeField]
    private float MoveSpeed = 40f;

    private float BulletFlySpeedPercent = 1; //子弹飞行速度百分比
    private float DamagePercent = 1;//伤害百分比
    private float InjuredPercent = 1;//受伤百分比
    private float CurePercent = 1;//治疗百分比
    private float MoveSpeedPercent = 1; //移速百分比
    private float HealthPercent = 1; //生命值百分比

    private float EnergySpeed = 1;

    [SyncVar]
    public bool isDead = false;

    

	// Use this for initialization
	void Start () {
        DefaultSet();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetAttack(5);
        }
    }

    public float GetSpeed()
    {
        return MoveSpeed * MoveSpeedPercent;
    }

    

    //初始化人物状态
    void DefaultSet() 
    {
        NowHealth = MaxHealth * HealthPercent;

    }
	
    
    
    [Client]
    public void GetAttack(float Damage)
    {
        CmdGetAttack(Damage);
    }

    [Command]
    public void CmdGetAttack(float Damage)
    {
        Debug.Log(name + " GetAttack!"+Damage);
        RpcGetAttack(Damage);
    }

    [ClientRpc]
    public void RpcGetAttack(float Damage)
    {
        if(isDead)
        {
            return;
        }
        NowHealth -= (Damage * InjuredPercent);
        Debug.Log(name + NowHealth);
        if (NowHealth < 0)
        {
            NowHealth = 0;
            Destroy(this.gameObject);
            Debug.Log(name + " Health<0 ,It Dead!");
        }
    }


    public float GetBulletFlySpeedPercent()
    {
        return BulletFlySpeedPercent;
    }

    public float GetDamagePercent()
    {
        return DamagePercent;
    }

    public float GetCurrentHealth()
    {
        return NowHealth;
    }
    public float GetMaxHealth()
    {
        return MaxHealth;
    }
    public float NowHealthPercent()
    {
        return NowHealth / MaxHealth;
    }
}
