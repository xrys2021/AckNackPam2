using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateData : MonoBehaviour
{
    public Rigidbody dataPack;
    public Transform Source;
    public GameObject Router;
    //public float Force;
    private float timer = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody dataPackage;
        //Making Object a Ridgedbody
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            dataPackage = Instantiate(dataPack, Source.position, Source.rotation) as Rigidbody;
            timer = 0.0f;
        }
    }

}
