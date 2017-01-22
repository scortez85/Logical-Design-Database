using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void changeMenu (string menuId)
    {
        if (menuId.Equals("Play"))
            SceneManager.LoadScene(1);
        else if (menuId.Equals("Quit"))
            Application.Quit();
            
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
