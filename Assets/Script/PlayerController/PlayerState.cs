using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    [SerializeField]
    private float MaxHealth = 200f;  //最大生命值
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


    

	// Use this for initialization
	void Start () {
        DefaultSet();

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
	
    public void GetAttack(float Damage)
    {
        NowHealth -= (Damage * InjuredPercent);
        if(NowHealth<0)
        {
            NowHealth = 0;
            //死亡
        }

    }

    public float GetBulletFlySpeedPercent()
    {
        return BulletFlySpeedPercent;
    }
}
