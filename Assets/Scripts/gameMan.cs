using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameMan : MonoBehaviour {

    public string netType;
    public bool haveNet = false;
    public GameObject netMan;
    public GameObject[] spawnPoints;
    public GameObject[] players;
    public bool playGame = false;

    void Start () {
        DontDestroyOnLoad(gameObject);
        
	
	}
    public void setNet(string type)
    {
        netType = type;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetAxis("Jump") > 0)
            playGame = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (Application.loadedLevel.Equals(1) && !haveNet)
        {
            if (netType.Equals("Host"))
                GameObject.Find("networkManager").GetComponent<netMan>().startHost();
            else if (netType.Equals("Join"))
                GameObject.Find("networkManager").GetComponent<netMan>().startClient();
            //GameObject netman = (GameObject)Instantiate(netMan);
            //netMan.name = "networkManager";
            //netman.GetComponent<netMan>().startHost();
            haveNet = true;
        }

        if (!playGame)
        {
            for (int k = 0; k < players.Length; k++)
            {
                players[k].transform.position = spawnPoints[k].transform.position;
                players[k].transform.rotation = spawnPoints[k].transform.rotation;
                players[k].GetComponent<Rigidbody>().isKinematic = false;
            }

        }
    }
}
