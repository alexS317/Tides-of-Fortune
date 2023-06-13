using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            DataStorage.instance.IncreaseHealthPotions();
            Destroy(this.gameObject);
        }
    }
    
}