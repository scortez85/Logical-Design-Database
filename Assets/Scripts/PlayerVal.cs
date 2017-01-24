using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerVal : NetworkBehaviour
{
    [SyncVar]
    public string playerName;
    [SyncVar]
    public long playerScore;
    private int numOfBoxes, damagedBoxes;
	
	void Start () {
        DontDestroyOnLoad(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
