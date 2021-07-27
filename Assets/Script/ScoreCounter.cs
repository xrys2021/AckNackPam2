using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public Packet[] packets = new Packet[0];
    public Dictionary<string, Packet> packetsDict = new Dictionary<string, Packet>();

    //Score Total Variables
    [SerializeField] private int score;

    void Start()
    {
        Debug.Log("I am attached to this gameObject" + this.gameObject);
        for (int i = 0; i < packets.Length; i ++)
        {
            Packet packet = packets[i];
            packetsDict.Add(packet.typeName, packet);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //On Collision, check what type and update the count for the different packets that are accepted.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Packet")
        {
            var packet = other.gameObject;
            //Parsing out name to pull out the packet type
            string Name = packet.name;
            Debug.Log("Name Variable" + Name);
            Name = Name.Trim();
            Debug.Log("Trime Variable " + Name);
            string[] ArrName = Name.Split(' ');
            
            if (packetsDict[ArrName[0]].maxCount < packetsDict[ArrName[0]].count)
            {
                packetsDict[ArrName[0]].count ++;
            }
        }
    }
    
    [Serializable]
    public class Packet
    {
        public string typeName;
        public bool isAccepted;
        public int count;
        public int maxCount;
    }
}
