using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Count both total maps and maps per level
            LevelStorage.Instance.IncreaseMaps();
            DataStorage.Instance.IncreaseTotalMaps();
            Destroy(this.gameObject);
        }
    }
}