using UnityEngine;
using System.Collections;

public class palletProp : MonoBehaviour {

    public GameObject pallet, propPallet;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (propPallet.activeSelf == true)
        {
            Instantiate(pallet, col.gameObject.transform.position, col.gameObject.transform.rotation);
            propPallet.SetActive(false);
        }
        //gameObject.SetActive(false);
    }
}
