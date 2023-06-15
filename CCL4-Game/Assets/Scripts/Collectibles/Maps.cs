using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            DataStorage.Instance.IncreaseMaps();
            Destroy(this.gameObject);
        }
    }
    
}