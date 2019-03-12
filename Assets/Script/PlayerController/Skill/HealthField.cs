using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthField : Skill {

    [SerializeField]
    private float CureRate;
    [SerializeField]
    private float DurationTime;

    public GameObject HealthFieldPrefab;
    private GameObject Field;

    // Use this for initialization
    void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
    }

    public override void DoSkillBody()
    {
        Field = Instantiate(HealthFieldPrefab, transform.position, Quaternion.identity);
        Field.GetComponent<HealthPower>().SetPowerEffect(CureRate);
        Invoke("destoryHealthField", DurationTime);
        Debug.Log("HealthField");
    }

    public override void CancleSkillBody()
    {
        Debug.Log("CancleHealthField");
    }
    public void destoryHealthField()
    {
        Destroy(Field);
    }

}
