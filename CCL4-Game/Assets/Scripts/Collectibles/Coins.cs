using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            DataStorage.Instance.IncreaseCoins();
            Destroy(this.gameObject);
        }
    }
    
}