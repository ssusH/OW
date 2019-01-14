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

    private float RespawnTime = 2f;

    [SyncVar]
    public bool isDead = false;

    [SerializeField]
    private GameObject[] DisableObjWhenDie;
    [SerializeField]
    private Behaviour[] DisableWhenDie;
    private bool[] wasEnabled;



    // Use this for initialization
    void Start () {

        
        DefaultSet();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetAttack(50,"Test");
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
    public float GetSpeed()
    {
        return MoveSpeed * MoveSpeedPercent;
    }

    

    //初始化人物状态
    void DefaultSet() 
    {
        wasEnabled = new bool[DisableWhenDie.Length];
        for (int i = 0; i < wasEnabled.Length; i++)
        {
            wasEnabled[i] = DisableWhenDie[i].enabled;
        }
        PlayerDefaultState();
    }

    //角色默认状态
    private void PlayerDefaultState()
    {
       
        NowHealth = MaxHealth * HealthPercent;
    }

    //角色死亡
    private void PlayerDie(string lastAttacker)
    {
        isDead = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        for (int i = 0; i < DisableWhenDie.Length; i++)
        {
            DisableWhenDie[i].enabled = false;
        }
        for( int i = 0;i< DisableObjWhenDie.Length;i++)
        {
            DisableObjWhenDie[i].SetActive(false);
        }

        if (isLocalPlayer)
        {
            GameManager.instance.ChangeMainCameraStatu(true);
        }
        

        StartCoroutine(Respawn());
    }


    [Client]
    public void GetAttack(float Damage,string form)
    {
        CmdGetAttack(Damage, form);
    }

    [Command]
    public void CmdGetAttack(float Damage, string form)
    {
        Debug.Log(name + " GetAttack!"+Damage);
        RpcGetAttack(Damage,form);
    }

    [ClientRpc]
    public void RpcGetAttack(float Damage, string form)
    {
        if(isDead)
        {
            return;
        }
        NowHealth -= (Damage * InjuredPercent);
        Debug.Log(name + NowHealth);
        if (NowHealth <= 0)
        {
            NowHealth = 0;
            PlayerDie(form);
            Debug.Log(name + " Health<0 ,It Dead!");
        }
    }

   
    private IEnumerator Respawn()
    {

        yield return new WaitForSeconds(RespawnTime);

        isDead = false;
        if (isLocalPlayer)
        {
            GameManager.instance.ChangeMainCameraStatu(false);
        }
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        for (int i = 0; i < DisableWhenDie.Length; i++)
        {
            DisableWhenDie[i].enabled = wasEnabled[i];
        }
        for (int i = 0; i < DisableObjWhenDie.Length; i++)
        {
            DisableObjWhenDie[i].SetActive(true);
        }

        
        PlayerDefaultState();

    }


}
