using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSNodeMap;

public class ScoreCounter : MonoBehaviour
{
    //Accepted type for field
    [SerializeField] private GameObject accept1;
    [SerializeField] private GameObject accept2;
    [SerializeField] private GameObject accept3;

    public string[] acceptedArray;
    //Counter
    [SerializeField] private int count1;
    [SerializeField] private int count2;
    [SerializeField] private int count3;

    void start()
    {
        //Making variables for array;
        acceptedArray[0] = accept1.name;
        acceptedArray[1] = accept2.name;
        acceptedArray[2] = accept3.name;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     var packet = other.gameObject;
    //     if (packet.tag == "Packet")
    //     {
    //         switch (packet.name)
    //         {
    //             case acceptedArray[0]:
    //                 count1++;
    //                 break;
    //             case acceptedArray[1]:
    //                 count2++;
    //                 break;
    //             case acceptedArray[2]:
    //                 count3++;
    //                 break;
    //             default:
    //                 Console.WriteLine("Moo");
    //                 break;
    //         }
    //     }
    // }

}
