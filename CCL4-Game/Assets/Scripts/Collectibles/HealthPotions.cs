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
            DataStorage.Instance.HealthPotions();
            Destroy(this.gameObject);
        }
    }
}