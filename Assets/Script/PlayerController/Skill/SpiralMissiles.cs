using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMissiles : Skill {

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
        Debug.Log("SpiralMissiles");
    }

    public override void CancleSkillBody()
    {
        Debug.Log("CancleSpiralMissiles");
    }


}
