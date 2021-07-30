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

    private void OnEnable()
    {
        maxCount = source.GetComponent<partitionCreation>().maxCount;
        currentHealth = maxCount;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth = maxCount- amount;

        float currentHealthPct = (float)currentHealth / (float)maxCount;
        OnHealthPctChanged(currentHealthPct);
    }

    public void Update()
    {
        var count = source.GetComponent<partitionCreation>().count;
        ModifyHealth(count);
    }
}