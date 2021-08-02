using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWorldSpace2 : MonoBehaviour
{
    [SerializeField]
    private int maxCount;
    [SerializeField] private GameObject source;

    private int currentHealth;
   

    public event Action<float> OnHealthPctChanged = delegate { };
    private void Start(){
        maxCount = source.GetComponent<dataTypeStorage>().maxCount;
    }
    private void OnEnable()
    {
        currentHealth = maxCount;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth = maxCount- amount;

        float currentHealthPct = (float)currentHealth / (float)maxCount;
        OnHealthPctChanged(currentHealthPct);
    }

    // public void Update()
    // {
    //     print("1 " + source);
    //     print("2 " + source.GetComponent<dataTypeStorage>());
    //     var count = source.GetComponentInChildren<partitionCreation>().count;
    //     ModifyHealth(count);
    // }
}