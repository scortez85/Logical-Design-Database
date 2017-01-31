using UnityEngine;
using System.Collections;

public class thirdCam : MonoBehaviour {

    public GameObject player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
	}
}
