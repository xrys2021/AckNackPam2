using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSNodeMap;

public class partitionCreation : MonoBehaviour
{
    //Variables for Drag and Drop
    [SerializeField] private Transform sourceDropOff;
    [SerializeField] private Transform resetPositionTrs;
    [SerializeField] private int count;
    [SerializeField] private int packageNumber;
    [SerializeField] private GameObject original;
    [SerializeField] private bool replacePacket = false;
    [SerializeField] private GameObject Parent1;

    private void Start()
    {
        var clone1 = Instantiate(original, sourceDropOff.position, sourceDropOff.rotation, Parent1.transform);
        clone1.GetComponent<DragDrop>().spawnLocationTrs = resetPositionTrs;
        clone1.name = original.name + " " + count;
    }

    private void Update()
    {
        if (replacePacket == true && count < packageNumber)
        {
            //Rigidbody dataPackage;
            var clone = Instantiate(original, sourceDropOff.position, sourceDropOff.rotation, Parent1.transform);
            DragDrop dragDrop = clone.GetComponent<DragDrop>();
            dragDrop.spawnLocationTrs = resetPositionTrs;
            clone.name = original.name + " " + count;
            count++;
            replacePacket = false;
        }
    }

    //Make 4 objects -->add component RidgedBody --> Unique Names(Name is the VARIABLE) in Unity not here
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Packet")
        {
            replacePacket = true;
        }
    }
}