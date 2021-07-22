using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSNodeMap;

public class partitionCreation : MonoBehaviour
{

    public int sourceNum;
    public Transform sourceDropOff;
    public int count;
    public int packageNumber;
    public GameObject original;
    [SerializeField] private bool replacePacket = false;

    private void Start()
    {
        Instantiate(original, sourceDropOff.position, sourceDropOff.rotation);
    }
    private void Update()
    {
        if (replacePacket == true && count < packageNumber)
        {
            //Rigidbody dataPackage;
            Instantiate(original, sourceDropOff.position, sourceDropOff.rotation);
            //dataPackage.gameObject.name
            replacePacket = false;
            count++;
        }
    }


    //Make 4 objects -->add component RidgedBody --> Unique Names(Name is the VARIABLE) in Unity not here

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Packets")
        {
            replacePacket = true;
        }
    }
}