using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {
    [SerializeField]
    private Transform RoomListPlane;
    [SerializeField]
    private GameObject RoomListButtonPrefab;

    public List<GameObject> roomList = new List<GameObject>();

    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();

        }
        RefreshRoomList();
    }

    public  void RefreshRoomList()
    {
        ClearRoomList();

        networkManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
    }

    public void joinMatch(MatchInfoSnapshot match)
    {
        networkManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        ClearRoomList();
    }

    private void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> responseData)
    {
        ClearRoomList();
        if (!success)
        {
            
            return;
        }
        if (responseData == null || responseData.Count == 0)
        {
            return;
        }
        foreach (MatchInfoSnapshot match in responseData)
        {
            Debug.Log(match.name);
            GameObject _room = (GameObject)Instantiate(RoomListButtonPrefab, RoomListPlane);
            _room.GetComponent<RoomListButton>().SetRoomButton(match, joinMatch);
            roomList.Add(_room);
        }

    }

    private void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }
}
