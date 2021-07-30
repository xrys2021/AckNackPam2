using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSNodeMap;

public class partitionCreation : MonoBehaviour
{
    //Variables for Drag and Drop
    [SerializeField] private Transform sourceDropOff;
    [SerializeField] private Transform resetPositionTrs;
    [SerializeField] public int count;
    [SerializeField] public int maxCount;
    [SerializeField] private GameObject original;
    [SerializeField] private bool replacePacket = false;
    [SerializeField] private GameObject Parent1;

    private void Start()
    {
        //Getting the data from original
        var origin = original.GetComponent<dataTypeStorage>();

        //Instantiate out packet
        var clone1 = Instantiate(original, sourceDropOff.position, sourceDropOff.rotation, Parent1.transform);
        clone1.GetComponent<DragDrop>().spawnLocationTrs = resetPositionTrs;
        clone1.name = origin.nameType + " " + count;
        maxCount = origin.maxCount;
    }

    private void Update()
    {
        if (replacePacket == true && count < maxCount)
        {
            //Getting the data from original
            var origin = original.GetComponent<dataTypeStorage>();

            //Instantiate out packet
            var clone = Instantiate(original, sourceDropOff.position, sourceDropOff.rotation, Parent1.transform);
            DragDrop dragDrop = clone.GetComponent<DragDrop>();
            dragDrop.spawnLocationTrs = resetPositionTrs;
            clone.name = origin.nameType + " " + count;
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