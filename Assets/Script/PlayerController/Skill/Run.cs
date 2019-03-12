using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : Skill {

    [SerializeField]
    private float EffectStrength;
    [SerializeField]
    private float DurationTime;

    public GameObject ParticleEffectPrefab;
    private GameObject ParticleEffect;

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
        GetComponent<PlayerState>().SetMoveSpeedPercent(EffectStrength);
        ParticleEffect = Instantiate(ParticleEffectPrefab,transform.position, Quaternion.identity,transform);
        Invoke("SkillOver", DurationTime);
        
    }

    private void SkillOver()
    {
        GetComponent<PlayerState>().SetMoveSpeedPercent(1);
        Destroy(ParticleEffect);
    }
}
