using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreManagerGlobal : MonoBehaviour
{
    //Variables for scoring
    private GameObject[] EndPoints;
    private GameObject[] packets;

    private GameObject[][] scoreCreated;

    private int maxScore;

    // Start is called before the first frame update
    void Start()
    {
        packets = GameObject.FindGameObjectsWithTag("Packet");
        EndPoints = GameObject.FindGameObjectsWithTag("Finish");
        // print($"EndPoints prints: {EndPoints}");
        foreach (var item in EndPoints)
        {
            print($"packets prints: {item.name}");
        }
        // createScore(packets, EndPoints);


    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void createScore(packets, Endpoints)
    // {
    //     for (int i = 0; i < Endpoints.Length; i++)
    //     {

    //     }
    // }

}
