using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject[] menus;
	public void changeMenu (string menuId)
    {
        if (menuId.Equals("Host"))//add network host
            SceneManager.LoadScene(1);
        else if (menuId.Equals("Net"))
        {
            menus[1].SetActive(false);
            menus[2].SetActive(true);
        }

        else if (menuId.Equals("User"))
        {
            menus[0].SetActive(false);
            menus[1].SetActive(true);
        }
        else if (menuId.Equals("Main"))
        {
            for (int k = 0; k < menus.Length; k++)
                menus[k].SetActive(false);
            menus[0].SetActive(true);
        }
        else if (menuId.Equals("Quit"))
            Application.Quit();

            
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
