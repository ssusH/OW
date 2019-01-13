using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    
    private Rigidbody2D rb;
    [SerializeField]
    private float lifeTime = 3f;
    private float Damage = 0F;
    private string shooterName;

    private void Start()
    {
        Destroy(this.gameObject,lifeTime);
    }

    public void SetDefaut(Vector3 speed,float AttackDamage,string _shooterName)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        Damage = AttackDamage;
        shooterName = _shooterName;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Environment")
            Destroy(this.gameObject);
        if(collision.tag == "Player"&& collision.name!=shooterName)
        {
            //Debug.Log("HIT MATCH !");
            
            collision.GetComponent<PlayerState>().RpcGetAttack(Damage, shooterName);
            //SendMessage("RpcGetAttack", Damage);
            Destroy(this.gameObject);
        }
    }




}
