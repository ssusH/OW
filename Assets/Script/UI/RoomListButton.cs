
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class RoomListButton : MonoBehaviour {

    public Text RoomName;
    public Text MapName;
    public Text RoomSize;

    public delegate void JoinRoomDelegate(MatchInfoSnapshot _match);
    public JoinRoomDelegate joinRoomDelegate;
    private MatchInfoSnapshot match;

    public void SetRoomButton(MatchInfoSnapshot _match, JoinRoomDelegate joinFunction)
    {
        match = _match;
        joinRoomDelegate = joinFunction;
        SetRoomInfo(match.name, "测试地图", match.currentSize + "/" + match.maxSize);
    }

    public void JoinGame()
    {
        joinRoomDelegate.Invoke(match);
    }

    private void SetRoomInfo(string roomName,string mapName,string roomSize)
    {
        RoomName.text = roomName;
        MapName.text = mapName;
        RoomSize.text = roomSize;
    }

    
	
}
