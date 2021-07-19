using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTo : MonoBehaviour
{
    //****Potential GameObjects for Game to assign****

    //Source Node Objects
    public GameObject Source;

    //Data Package Type Objects
    public GameObject dataPackage1;

    //Endpoint Terminals Objects
    public GameObject Ep1;
    public GameObject EP2;
    public GameObject EP3;
    public GameObject EP4;
    
    //Router Object
    public GameObject Router;
    
    //Node Point Objects
    public GameObject Node1;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject Node4;
    public GameObject Node5;
    public GameObject Node6;
    public GameObject Node7;
    public GameObject Node8;
    public GameObject Node9;

    //Forces
    public float Force;

    //Selection of Player
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player5;

    //***Functions for the Game Movement***
    void Update()
    {
        //Look up MoveTowards FUNCTION
        transform.position = Vector3.MoveTowards(transform.position, Router.transform.position, Force*Time.deltaTime);

        //if object collides wtih node --> change vector3.movetowards[2] to next node
        // if object collides with EndPoint --> Endpoint(score script) ++ and concatinates object name to list --> if NACK, send NACK
            //WIN CONDITIONS: switch (movie = %, photo = completion + concat [boolean], text = boolean, email = boolean)
            //Score after all completed (Macination will help here)

        //Instantiate for multiplying data packages
    }
}
