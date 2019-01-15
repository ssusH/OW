using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreatHost : MonoBehaviour {

    private string RoomName;
    private string RoomKey = "";
    private string MapName;
    private string RoomMode;
    private uint RoomSize = 6;


    private NetworkManager networkManager;
    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetRoomName(string roomName)
    {
        RoomName = roomName;
    }
    public void SetRoomKey(string roomKey)
    {
        RoomKey = roomKey;
    }
    public void SetMapName(string roomMapName)
    {
        MapName = roomMapName;
    }
    public void SetRoomMode(string roomRoomMode)
    {
        RoomMode = roomRoomMode;
    }

    public void CreatMatch()
    {
        if(RoomName == "" && RoomName == null)
        {
            Debug.Log("Please Input RoomName!");
            return;
        }
        Debug.Log("RoomName:" + RoomName +" RoomKey:" +RoomKey + " MapName:" + MapName + " RoomMode:" + RoomMode);
        networkManager.matchMaker.CreateMatch(RoomName, RoomSize, true,RoomKey, "", "", 0, 0, networkManager.OnMatchCreate);
    }


}
