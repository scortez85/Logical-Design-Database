using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject[] menus;
    public Text fName, lName, email, pass, passConfim, male, female;

    void closeMenus()
    {
        for (int k = 0; k < menus.Length; k++)
            menus[k].SetActive(false);
    }
	public void changeMenu (string menuId)
    {
        if (menuId.Equals("Host"))//add network host
            SceneManager.LoadScene(1);
        else if (menuId.Equals("Highscores"))
        {
            closeMenus();
            menus[3].SetActive(true);
        }
        else if (menuId.Equals("Net"))
        {
            closeMenus();
            menus[2].SetActive(true);
        }

        else if (menuId.Equals("User"))
        {
            closeMenus();
            menus[1].SetActive(true);
        }
        else if (menuId.Equals("Main"))
        {
            closeMenus();
            menus[0].SetActive(true);
        }
        else if (menuId.Equals("Quit"))
            Application.Quit();

            
    }
	void Start () {
	
	}
    public void getPlayerInfo()
    {

    }
	
	// Update is called once per frame
	void Update () {
	}
}
