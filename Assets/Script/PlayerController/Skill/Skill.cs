using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum skill_bar_name
{
    b_Skill_1,
    b_Skill_2,
    b_Skill_3
}

public abstract class Skill : MonoBehaviour {

    [SerializeField]
    protected KeyCode hotKey;
    [SerializeField]
    protected skill_bar_name UiBarName;
    [SerializeField]
    protected float Skill_Cd;

    protected SkillBar SkillUI;

    protected bool SkillInCd;

    [SerializeField]
    protected Sprite SkillIcon;

    // Use this for initialization
    protected void Start () {

    }
	
	// Update is called once per frame
	protected void Update () {
        //延迟获取技能UI条
        if(SkillUI ==null)
        {
            GameObject UIbar = GameObject.Find(UiBarName.ToString());
            if (UIbar == null)
                return;
            SkillUI = UIbar.GetComponent<SkillBar>();
            SkillUI.Initialize(SkillIcon);
            return;
        }
        if (Input.GetKeyDown(hotKey)&&!SkillInCd)
        {
            DoSkillBody();
            SkillInCd = true;
            Debug.Log("CD is begin" + System.DateTime.Now);
            Invoke("SkillCdOver", Skill_Cd);
            SkillUI.EnterSkillCd(Skill_Cd);


            
        }
        if (Input.GetKeyUp(hotKey))
        {
            CancleSkillBody();
        }
    }

    public abstract void DoSkillBody();

    public abstract void CancleSkillBody();

    protected void SkillCdOver()
    {
        SkillInCd = false;
        Debug.Log("CD is Over"+System.DateTime.Now);
    }
    

}
