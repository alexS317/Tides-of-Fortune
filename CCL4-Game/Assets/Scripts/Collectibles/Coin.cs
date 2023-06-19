using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            DataStorage.Instance.IncreaseCoins();

            // Destroy the coin game object
            Destroy(this.gameObject);
        }
    }
}