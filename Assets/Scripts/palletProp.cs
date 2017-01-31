using UnityEngine;
using System.Collections;

public class palletProp : MonoBehaviour {

    public GameObject pallet;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        //if (gameObject.activeSelf == true)
        {
            Instantiate(pallet, col.gameObject.transform.position, col.gameObject.transform.rotation);
            gameObject.SetActive(false);
        }
        //gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
    }
}
