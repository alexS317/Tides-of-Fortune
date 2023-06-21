using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPotion : MonoBehaviour
{
    
    // Check if the colliding object has the "Player" tag
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataStorage.Instance.CollectHealthPotions();
            // Destroy the coin game object
            Destroy(this.gameObject);
        }
    }
}