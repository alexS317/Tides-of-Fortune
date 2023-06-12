using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            DataStorage.instance.IncreasePotions();
            Destroy(this.gameObject);
        }
    }
    
}