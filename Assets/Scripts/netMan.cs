﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class netMan : NetworkBehaviour
{

    private NetworkManager netManager;
    void Start()
    {
        netManager = GetComponent<NetworkManager>();

    }
    

    // Update is called once per frame
    void Update()
    {

    }
  
    public void startHost()
    {
        netManager.StartHost();

    }
    public void startClient()
    {
        netManager.StartClient();
        //GameObject.Find("menuUI").GetComponent<menuUI>().hideNetUI();
    }

}
