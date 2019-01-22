using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class QuitGame : MonoBehaviour {


    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();

        }
    }

    public void QuitRoom()
    {
        networkManager.StopHost();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
