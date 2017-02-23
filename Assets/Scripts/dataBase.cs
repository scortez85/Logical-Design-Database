using UnityEngine;
using Mono;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Mono.Security.Cryptography;
using UnityEngine.UI;

public class dataBase : MonoBehaviour {
    public Text highScoreText;
    StreamReader dataBaseIn;
    StreamWriter dataBaseOut;
    Hashtable Database;
    List<int> sortedDatabase;
    public Text[] scoreText;
    void Start() {
        scoreText = new Text[10];
        sortedDatabase = new List<int>();
        Database = new Hashtable();
        //highScoreText.text = "Steven : 50";
       
       loadDataBase();
        string scores = "";
        for (int k=0;k<sortedDatabase.Count;k++)
        {
            Vector3 newPos = highScoreText.transform.position;
            scoreText[k] = (Text)Instantiate(highScoreText, highScoreText.gameObject.transform.position, highScoreText.gameObject.transform.rotation);
            scoreText[k].text = sortedDatabase[k].ToString();
            scoreText[k].transform.parent = highScoreText.transform;
            newPos.y -= 25;
            scoreText[k].transform.position = newPos;
            //scores += sortedDatabase[k].ToString();
        }
        highScoreText.text = scores;

    }
    private void reverseAndRetrieveData()
    {
        foreach (int k in Database.Values)
            sortedDatabase.Add(k);
        sortedDatabase.Sort();
        sortedDatabase.Reverse();
    }
    public void addRecord(string name, int value)
    {
        Database.Add(name, value);
        sortedDatabase.Clear();
        reverseAndRetrieveData();

    }
	public void loadDataBase()
    {
        dataBaseIn = new StreamReader("Assets\\Database.dat");
        string myLine;

        while ((myLine = dataBaseIn.ReadLine()) != null)
            addRecord(myLine.Split(':')[0], int.Parse(myLine.Split(':')[1]));
        dataBaseIn.Close();

    }
    public void saveDataBase()
    {
        dataBaseOut = new StreamWriter("Assets\\Database.dat");
        for (int k = 0; k < sortedDatabase.Count; k++)
            dataBaseOut.WriteLine(sortedDatabase[k].ToString() + ":" + Database[sortedDatabase[k].ToString()]);
        dataBaseOut.Close();
    }
	// Update is called once per frame
	void Update () {
	
	}
    string retrieveInfo (int num)
    {
        foreach (string str in Database.Keys)
        {
            if (Database[str].Equals(num))
                return str;
        }

        return "";
    }
    //debug
    void OnGUI()
    {
        /*
        for (int k = 0; k < sortedDatabase.Count; k++)
            GUI.Label(new Rect(10, 10 + (k * 24), 2566, 24), sortedDatabase[k].ToString() + " : " + retrieveInfo(sortedDatabase[k]));
        */
    }
}
