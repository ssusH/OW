using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Camera SinceCamera;

    [SerializeField]
    private GameObject MainMenue;

    private static Dictionary<string,PlayerState> PlayerList = new Dictionary<string, PlayerState>();

    public static GameManager instance;

    private const string PLAYER_ID_PREFIX = "Player";

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("has only one gamemanager");
        }
        instance = this;
    }


    public static void RegisterPlayer(string _netID, PlayerState _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        PlayerList.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }

    public void RemovePlayer(string name)
    {
        PlayerList.Remove(name);
    }

    public void ChangeMainCameraStatu(bool MainCameraStatu)
    {
        if (SinceCamera == null)
        {
            return;
        }
        SinceCamera.gameObject.SetActive(MainCameraStatu);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenue.SetActive(!MainMenue.active);
        }
    }

    public void quitCurrentRoom()
    {

    }
}
