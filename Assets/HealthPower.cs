using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HealthPower : MonoBehaviour {

    private float powerEffect= -5;
   

	// Update is called once per frame
	void Update () {
		if(GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Kinematic)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.Find("GroudCheck").position, Vector2.down, 0.2f, 1 << LayerMask.NameToLayer("Groud"));
            if (hit.transform!=null && hit.transform.name == "Grid")
            {
                Debug.Log("Grid");  
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
               GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
	}

    public void SetPowerEffect(float cureRate)
    {
        powerEffect = -cureRate;
    }
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerState>().RpcGetAttack(powerEffect/2 * Time.deltaTime, "HealthField");
        }
    }





}
