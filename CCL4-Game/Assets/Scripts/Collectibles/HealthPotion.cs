using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPotion : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataStorage.Instance.CollectHealthPotions();
            //DataStorage.Instance.IncreasePlayerHealth();
            Destroy(this.gameObject);
        }
    }
}