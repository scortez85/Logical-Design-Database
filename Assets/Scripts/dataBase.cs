using UnityEngine;
using Mono;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Mono.Security.Cryptography;
using UnityEngine.UI;

public class dataBase : MonoBehaviour {
    public GameObject[] newPlayerInfo;
    public GameObject[] highScoreText;
    public class Player
    {
        private string fName, lName, gender;
        private double score;
        private int id;

        public Player(string f, string l, string g, double s, int i)
        {
            this.fName = f;
            this.lName = l;
            this.gender = g;
            this.score = s;
            this.id = i;
        }

        public string getFirstName()
        {
            return this.fName;
        }
        public string getLastName()
        {
            return this.lName;
        }
        public string getGender()
        {
            return this.gender;
        }
        public int getId()
        {
            return this.id;
        }
        public double getScore()
        {
            return this.score;
        }

    }
    private List<Player> playerList = new List<Player>();
  
    void Update()
    {   
       

    }
    public void setHighScoresVisible(bool value)
    {
        highScoreText[0].GetComponent<Text>().text = "Names";
        highScoreText[1].GetComponent<Text>().text = "Scores";
        for (int k=0;k<playerList.Count;k++)
        {
            highScoreText[0].GetComponent<Text>().text += "\n" + playerList[k].getFirstName() + " " + playerList[k].getLastName();
            highScoreText[1].GetComponent<Text>().text += "\n" + playerList[k].getScore();
        }
    }
    void Start()
    {

        
        loadDatabase();
        playerList = sortDatabase();

       // newPlayer("Steven3", "c", "Male");
        saveDatabase();

    }
    //void newPlayer(string f, string l, string g)
    public void newPlayer()
    {
        string f = newPlayerInfo[0].GetComponent<Text>().text;
        string l = newPlayerInfo[1].GetComponent<Text>().text;
        string g = "";
        if (newPlayerInfo[2].GetComponent<Toggle>().isOn)
        {
            g = "Male";
            newPlayerInfo[3].GetComponent<Toggle>().isOn = false;
        }
        else if (newPlayerInfo[3].GetComponent<Toggle>().isOn)
        {
            g = "Female";
            newPlayerInfo[2].GetComponent<Toggle>().isOn = false;
        }

        if (playerList.Count > 0)
        {
            for (int k = 0; k < playerList.Count; k++)
            {
                if (f.Equals(playerList[k].getFirstName()) && l.Equals(playerList[k].getLastName()))
                    return;
            }
        }
            List<int> idList = new List<int>();
            for (int k = 0; k < playerList.Count; k++)
            {
                idList.Add(playerList[k].getId());
            }
            idList.Sort();
            playerList.Add(new Player(f, l, g, 0f, idList[idList.Count - 1] + 1));
            saveDatabase();
        
    }
    List<Player> sortDatabase()
    {
        List<Player> returnList = new List<Player>();
        List<double> dList = new List<double>();
        for (int k=0;k<playerList.Count;k++)
        {
            dList.Add(playerList[k].getScore());
        }

        dList.Sort();
        dList.Reverse();
        for (int k=0;k<dList.Count;k++)
        {
            for (int i=0;i<playerList.Count;i++)
            {
                if (playerList[i].getScore() == dList[k])
                    returnList.Add(playerList[i]);
            }
        }

        return returnList;
    }
    void loadDatabase()
    {
        StreamReader inFile = new StreamReader("Assets\\Database.dat");

        string myLine = "";
        while ((myLine = inFile.ReadLine())!=null)
        {
            playerList.Add(new global::dataBase.Player(myLine.Split(':')[0], myLine.Split(':')[1], myLine.Split(':')[2], double.Parse(myLine.Split(':')[3]), int.Parse(myLine.Split(':')[4])));
        }
        inFile.Close();
    }
    void saveDatabase()
    {
        StreamWriter outFile = new StreamWriter("Assets\\Database.dat");

        for (int k=0;k<playerList.Count;k++)
        {
            outFile.WriteLine(playerList[k].getFirstName() + ":" + playerList[k].getLastName() + ":" +
                playerList[k].getGender() + ":" + playerList[k].getScore() + ":" + playerList[k].getId());

           
        }
        outFile.Close();
    }
    void OnGUI()
    {
        //if (showHighScores)
        {
            //for (int k = 0; k < playerList.Count; k++)
                //GUI.Label(new Rect(500, 10 + (k * 24), 2566, 24), playerList[k].getFirstName() + " :: " + playerList[k].getScore());
        }
    }

    
}
