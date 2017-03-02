using UnityEngine;
using Mono;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Mono.Security.Cryptography;
using UnityEngine.UI;

public class dataBase : MonoBehaviour {
    public class Player
    {
        private string fName,lName,gender,email,password;
        private int score,id;

        public Player(string fName,string lName,int score,string email,string password,int ID)
        {
            this.fName = fName;
            this.lName = lName;
            this.score = score;
            this.email = email;
            this.password = password;
            this.id = ID;
        }
        public string getFname()
        {
            return this.fName;
        }
        public string getLname()
        {
            return this.lName;
        }
        public string getGender()
        {
            return this.gender;
        }
        public string getEmail()
        {
            return this.email;
        }
        public string getPass()
        {
            return this.password;
        }
        public int getScore()
        {
            return this.score;
        }
        public int getId()
        {
            return this.id;
        }

    }
    public List<Player> playerList = new List<Player>();

    void Start()
    {
        loadDataBase();
       
        
        //SaveDataBase();
    }

    public void loadDataBase()
    {
        StreamReader dataBaseIn = new StreamReader("Assets\\Database.dat");
        string myLine;

        while ((myLine = dataBaseIn.ReadLine()) != null)
            playerList.Add(new global::dataBase.Player(myLine.Split(':')[0], myLine.Split(':')[1], int.Parse(myLine.Split(':')[2]), myLine.Split(':')[3], myLine.Split(':')[4], int.Parse(myLine.Split(':')[5])));
        dataBaseIn.Close();
        playerList = SortedData();
    }
    public void newPlayer(string fName, string lName, int score, string email, string password, int ID)
    {
        playerList.Add(new global::dataBase.Player(fName, lName, score, email, password, ID));
        playerList = SortedData();
    }
    public void SaveDataBase()
    {
        StreamWriter outFile = new StreamWriter("Assets\\Database.dat");
        for (int k=0;k<playerList.Count;k++)
        {
            outFile.Write(playerList[k].getFname() + ":" + playerList[k].getLname() + ":" + playerList[k].getScore() + ":" + playerList[k].getEmail() +":" + playerList[k].getPass() + ":" + playerList[k].getId());
            outFile.WriteLine();
        }
        outFile.Close();
    }
    public List<Player> SortedData()
    {
        List<Player> list = new List<Player>();
        List<int> myList = new List<int>();

        for (int k=0;k<playerList.Count-1;k++)
        {
            myList.Add(playerList[k].getScore());
            
        }
        myList.Sort();
        myList.Reverse();
        for (int k=0;k<myList.Count;k++)
        {
            for (int i =0;i<playerList.Count;i++)
            {
                if (playerList[i].getScore() == myList[k])
                    list.Add(playerList[i]);
            }
        }
        return list;
    }
    void OnGUI()
    {
      //  for (int k = 0; k < playerList.Count; k++)
        //    GUI.Label(new Rect(10, 10 + (k * 24), 2566, 24), playerList[k].getFname() +" :: " + playerList[k].getScore());
    }

    
}
