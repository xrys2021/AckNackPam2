// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using System;

// public class ScoreStorage : MonoBehaviour
// {
//     //Varibles for modification
//     public scoreObj[] scores = new scoreObj[0];
//     public Dictionary<scoreObj, int> scoresDict = new Dictionary<scoreObj, int>();
//     //Variables for Score
//     public int maxScore;
//     public int score;
//     //Variable to see if packets are still on the field --> used to transition to achievement scene
//     private GameObject sensorField;

//     void Start()
//     {
//         //Add Accepted types into the 
//         for (int i = 0; i < scores.Length; i++)
//         {
//             scoreObj setUp = scores[i];
//             scoresDict.Add(setUp, setUp.count);
//         }
//         print(scores);

//         maxScoreCreation(scores);
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.tag == "Packet")
//         {
//             string name = other.name.Split(' ')[0].Trim();
//             print(name);
//             other.name = name;

//         }
//     }

//     private void maxScoreCreation(scores)
//     {

//     }

//     [Serializable]
//     public class scoreObj
//     {
//         public string nameType;
//         public GameObject accepted;
//         public int count;

//     }

// }
