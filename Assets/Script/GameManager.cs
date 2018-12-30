using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Camera SinceCamera;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("has only one gamemanager");
        }
        instance = this;
    }


    public void ChangeMainCameraStatu(bool MainCameraStatu)
    {
        if (SinceCamera == null)
        {
            return;
        }
        SinceCamera.gameObject.SetActive(MainCameraStatu);

    }
}
