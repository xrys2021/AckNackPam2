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
	[SerializeField] private Material Material1;
	[SerializeField] private Material Material2;
	[SerializeField] private bool selected;
	[SerializeField] private Map mapping;
	public Node destination;
	[SerializeField] Node source;
	public Transform spawnLocationTrs;
	public GameObject original;
	bool isDragging;


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

	void Update ()
	{
		RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
		if (Input.GetMouseButtonDown(0))
		{
			for (int i = 0; i < hits.Length; i ++)
			{
				RaycastHit hit = hits[i];
				DragDrop dragDrop = hit.collider.GetComponent<DragDrop>();
				if (dragDrop == this)
				{
					isDragging = true;
					OnMouseDown ();
					break;
				}
			}
		}
		else if (isDragging)
		{
			OnMouseDrag ();
		}
		if (Input.GetMouseButtonUp(0) && isDragging)
		{
			isDragging = false;
			OnMouseUp ();
		}
	}

	//Functions for highlighting node
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Source"))
		{
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
			Debug.Log(source);
			Debug.Log(mapping);
			Debug.Log(pack);
			transform.position = source.transform.position;
			pack.Initialize(mapping, source);
			pack.MoveToTarget(destination);
		}
	}

}