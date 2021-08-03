using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreStorage : MonoBehaviour
{
    //Varibles for modification
    public scoreObj[] scores = new scoreObj[0];
    public Dictionary<int, scoreObj> scoresDict = new Dictionary<int, scoreObj>();
    //Variables for Score
    public int maxScore;
    public int score;

    void Start()
    {
        //Add Accepted types into the 
        for (int i = 0; i < scores.Length; i++)
        {
            scoreObj setUp = scores[i];
            scoresDict.Add(setUp.count, setUp);
        }
        print(scores);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Packet")
        {
            string name = other.name.Split(' ')[0].Trim();
            print(name);

            // for (int i = 0; i < scoresDict.Length; i++)
            // {
                
            // }

            
        }
    }









    [Serializable]
    public class scoreObj
    {
        public int count;
        public GameObject accepted;
          
    }

}
