using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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
        }
        else
        {
           
        }
	}


    private void DisableCompoents()
    {
        for (int i = 0; i < ComponentsBehaviours.Length; i++)
        {
            ComponentsBehaviours[i].enabled = false;
        }
    }

    private void ResetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(RemotePlayerLayerName);
    }
}
