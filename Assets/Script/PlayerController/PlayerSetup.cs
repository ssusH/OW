using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] ComponentsBehaviours;

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
        }
        
    }


    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        GameManager.RegisterPlayer(_netID, GetComponent<PlayerState>());
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

        }
        GameManager.instance.RemovePlayer(transform.name);
        

    }
}
