using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JSNodeMap;
using System;

public class Buffer : MonoBehaviour
{

    //Variables for Buffer
    [SerializeField] private Node node;
    [SerializeField] private int bufferLimit;
    List<Agent> agents = new List<Agent>();
    [SerializeField] private Image imagePrefab;
    [SerializeField] private Transform imageParent;
    private Image[] images = new Image[0];
    public float agentStopDuration;
    public Color defaultImageColor;
    public AgentType[] agentTypes = new AgentType[0];
    public Dictionary<string, AgentType> agentTypesDict = new Dictionary<string, AgentType>();




    void Start()
    {
        
        images = new Image[bufferLimit];
        for (int i = 0; i < bufferLimit; i++)
        {
            images[i] = Instantiate(imagePrefab, imageParent);
        }
        for (int i = 0; i < agentTypes.Length; i++)
        {
            AgentType agentType = agentTypes[i];
            agentTypesDict.Add(agentType.name, agentType);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Packet")
        {
            Agent agent = other.GetComponent<Agent>();
            if (agents.Count + 1 <= bufferLimit)
            {
                agents.Add(agent);
                agent.Pause();
                Image image = images[agents.Count - 1];
                image.color = agent.GetComponentInChildren<MeshRenderer>().material.color;
                StartCoroutine(AgentStopRoutine(agent));
            }
            else
            {
                Destroy(other.gameObject);
                DragDrop dragDrop = other.GetComponent<DragDrop>();
                // string agentTypeName = other.name;
                // int indexOfSpsace = other.name.IndexOf(" ");
                // if (indexOfSpsace != -1)
                //     agentTypeName = agentTypeName.Remove(indexOfSpsace);
                // print(" Yay " + agentTypeName);
                // if (dragDrop.spawnLocationTrs.name.Contains("1"))
                //     Instantiate(agentTypesDict[agentTypeName].dragDrop1, dragDrop.spawnLocationTrs.position, Quaternion.identity);
                // else
                // Instantiate(agentTypesDict[agentTypeName].dragDrop2, dragDrop.spawnLocationTrs.position, Quaternion.identity);
                Instantiate(dragDrop.original,dragDrop.spawnLocationTrs.position,Quaternion.identity);
            }
        }
    }

    IEnumerator AgentStopRoutine(Agent agent)
    {
        yield return new WaitForSeconds(agentStopDuration);
        Image image = images[agents.Count - 1];
        image.color = defaultImageColor;
        agent.Play();
        agents.Remove(agent);
    }

    [Serializable]
    public struct AgentType
    {
        public DragDrop dragDrop1;
        // public DragDrop dragDrop2;
        public string name;
    }
}
