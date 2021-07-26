using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSNodeMap;


public class DragDrop : MonoBehaviour
{
    //Drag and Drop Mechanic Variables
    private Vector3 mOffset;
    private float mZCoord;
    [SerializeField] private bool draggable;

    //Illumination variables
    [SerializeField] private bool sourceCollide;
    [SerializeField] private Material Material1;
    [SerializeField] private Material Material2;
    [SerializeField] private bool selected;
    [SerializeField] private Map mapping;
    public Node destination;
    [SerializeField] Node source;
    public Transform spawnLocationTrs;


    //Drag Functions
    void OnMouseDown()
    {
        if (draggable == true)
        {
            mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;
            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
    }
    //Camera to move object functions
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    //Drag Function
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    //Functions for highlighting node
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Source"))
        {
            sourceCollide = true;
            other.gameObject.GetComponent<MeshRenderer>().material = Material1;
            selected = true;
            source = other.GetComponent<Node>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Source"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material = Material2;
            source = null;
            selected = false;

        }
    }

    //+ Agent functions
    private void OnMouseUp()
    {
        if (draggable == true && selected == true)
        {
            draggable = false;
            var pack = GetComponent<Agent>();
            pack.Initialize(mapping,source);
            pack.MoveToTarget(destination);
        }
    }
    
}