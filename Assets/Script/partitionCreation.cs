using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partitionCreation : MonoBehaviour
{
    public int sourceNum;
    public Transform sourceDropOff;
    public int count;
    public int packageNumber;
    public string type;
    public Rigidbody prefab;
    public GameObject destination;
    [SerializeField] private bool replacePacket = false;

    private void Update()
    {
        if (replacePacket == true && count < packageNumber)
        {
            Rigidbody dataPackage;
            dataPackage = Instantiate(prefab, sourceDropOff.position, sourceDropOff.rotation) as Rigidbody;
            count++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Packets")
        {
            replacePacket = true;
        }
    }
}