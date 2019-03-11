using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : Skill {
   

    // Use this for initialization
    void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
    }

    public override void CancleSkillBody()
    {
        Debug.Log("CancleRun");
    }

    public override void DoSkillBody()
    {
        Debug.Log("DoRun");
    }
}
