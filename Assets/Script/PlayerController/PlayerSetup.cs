using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] ComponentsBehaviours;

    [SerializeField]
    private GameObject BattleUiPrefab;
    private GameObject BattleUi;
    [SerializeField]
    private string RemotePlayerLayerName;



    // Use this for initialization
    void Start () {
		if(!isLocalPlayer)
        {
            DisableCompoents();
            ResetLayer();
            //SetMemberTag();
           
        }
        else
        {
            GameManager.instance.ChangeMainCameraStatu(false);
            BattleUi = Instantiate(BattleUiPrefab);
            BattleUi.GetComponent<BattleUI>().SetPlayerSetUp(this);
        }
        
    }


    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        GameManager.RegisterPlayer(_netID, GetComponent<PlayerState>());
    }

    public void SetBattleUIDefault(BattleUI battleUI)
    {
        battleUI.SetDefaultUI(GetComponent<PlayerState>(), GetComponent<PlayerAttack>().GetCurrentWeapon());
    }

    private void DisableCompoents()
    {
        for (int i = 0; i < ComponentsBehaviours.Length; i++)
        {
            ComponentsBehaviours[i].enabled = false;
        }
    }

    public void SetMemberTag()
    {
        tag = "MatchPlayer";
    }

    private void ResetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(RemotePlayerLayerName);
    }


    private void OnDisable()
    {
        if (isLocalPlayer)
        {
            GameManager.instance.ChangeMainCameraStatu(true);
            Destroy(BattleUi);
        }
        GameManager.instance.RemovePlayer(transform.name);
        

    }
}
