using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour
{
    public Packet[] packets = new Packet[0];
    public Dictionary<string, Packet> packetsDict = new Dictionary<string, Packet>();

    //Score Total Variables=
    [SerializeField] private int score;

    //Variables for HealthBar (taken from buffer script)
    [SerializeField] private GameObject healthBar;
    private GameObject[] bars = new GameObject[0];
    [SerializeField] private Transform healthParent;

    void Start()
    {
        //To add the different packets to the dictionary
        for (int i = 0; i < packets.Length; i++)
        {
            Packet packet = packets[i];
            packetsDict.Add(packet.typeName, packet);
        }
        //Instantiating the different accepted packets as health bars/EndPoint
        bars = new GameObject[packets.Length];
        for (int i = 0; i < packets.Length; i++)
        {
            if (packets[i].isAccepted==true)
            {
                bars[i] = Instantiate(healthBar, healthParent);
            }
        }
    }

    //Health Bar Scripts (The Collision Scripts below)
    public event Action<float> OnHealthPctChanged = delegate { };
    public void ModifyHealth(int amount, int max){
        Debug.Log($"amount: {amount} and max: {max}");
        float currentScorePct = (float)score/(float)max;
        Debug.Log(currentScorePct);
        OnHealthPctChanged(currentScorePct);
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
            Debug.Log("Trim Variable " + Name);
            string[] ArrName = Name.Split(' ');
            Debug.Log($"ArrName = {ArrName[0]}");

            //Variable to store new name
            var nametype = packetsDict[ArrName[0]];
            Debug.Log($"the name type is {nametype}");

            if (nametype.maxCount > nametype.count)
            {
                nametype.count++;
                Debug.Log($"the {nametype} count is {nametype.count} and the max count is {nametype.maxCount}");
            
                ModifyHealth(nametype.count,nametype.maxCount);
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
