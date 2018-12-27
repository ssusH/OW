using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private CinemachineVirtualCamera camera;

	
	
	// Update is called once per frame
	void Update () {
		
	}

    public CinemachineVirtualCamera GetMainCamera()
    {
        return camera;
    }
}
