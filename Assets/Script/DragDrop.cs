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
    [SerializeField] private bool clicked;

    //Illumination variables
    [SerializeField] private bool sourceCollide;
    [SerializeField] private Material Material1;
    [SerializeField] private Material Material2;
    [SerializeField] private bool selected;
    public GameObject destination;
    [SerializeField] GameObject source;


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

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    //Illumination + Agent functions
    private void OnMouseUp()
    {
        if (draggable == true && selected == true)
        {
            draggable = false;
            
        }
    }
    //On Mouse Drop
    //Agent.Intialize(NodeMap);
    //Agent.MovetoTarget(destination);
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "source" && clicked == true)
        {
            other.gameObject.GetComponent<MeshRenderer>().material = Material1;
            selected = true;
            source = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "source" && clicked == true)
        {
            other.gameObject.GetComponent<MeshRenderer>().material = Material2;
        }
    }
}