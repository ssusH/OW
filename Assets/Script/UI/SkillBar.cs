using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour {

    [SerializeField]
    private float skill_cd_length;
    private GameObject cdTextGameObject;
    private GameObject cdSpriteMaskGameObject;
    private Text cdText;
    private Image cdSpriteMask;
  

    public void Initialize(Sprite sprite)
    {
        transform.Find("skill_icon").GetComponent<Image>().sprite = sprite;
        cdTextGameObject = transform.Find("skill_cd").gameObject;
        cdSpriteMaskGameObject = transform.Find("skill_cd_mask").gameObject;
        cdText = cdTextGameObject.GetComponent<Text>();
        cdSpriteMask = cdSpriteMaskGameObject.GetComponent<Image>();
        Debug.Log(gameObject.name);
    }

    public void EnterSkillCd(float cd)
    {
        Debug.Log("EnterCD:" + cd);
        skill_cd_length = cd;
        cdSpriteMask.fillAmount = 1;
        cdTextGameObject.SetActive(true);
        cdSpriteMaskGameObject.SetActive(true);
        InvokeRepeating("SkillCd", 0, Time.deltaTime);
        Invoke("SkillCdOver", cd);
    }

    public void SkillCd()
    {
        Debug.Log("cd...");
        //int cd = (int)(skill_cd_length - 0.2f);
        //cdText.text = cd.ToString();
        cdSpriteMask.fillAmount -= Time.deltaTime/skill_cd_length;
        cdText.text = ((int)(cdSpriteMask.fillAmount * skill_cd_length)+1).ToString();
    }

    public void SkillCdOver()
    {
        CancelInvoke("SkillCd");
        transform.Find("skill_cd").gameObject.SetActive(false);
        transform.Find("skill_cd_mask").gameObject.SetActive(false);
    }



   

}
