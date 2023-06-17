using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Local storage for levels
public class LevelStorage : MonoBehaviour
{
    public static LevelStorage Instance;
    
    public int MapsInLevel { get; private set; }

    private void Start()
    {
        if (Instance == null) Instance = this;
    }

    public void IncreaseMaps()
    {
        MapsInLevel++;
        Debug.Log("Maps in level storage: " + MapsInLevel);
    }
}