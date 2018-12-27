using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    
    private Rigidbody2D rb;
    [SerializeField]
    private float lifeTime = 3f;

    private void Start()
    {
        Destroy(this.gameObject,lifeTime);
    }

    public void SetVelocity(Vector3 speed)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Environment")
            Destroy(this.gameObject);
    }

}
