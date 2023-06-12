using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour
{
    public static DataStorage instance;
    
    public float playTime
    {
        get;
        private set;
    }
    
    [field: SerializeField] private int requiredMaps;
    
    public int scoreMaps
    {
        get;
        private set;
    }
    
    public int scoreCoins
    {
        get;
        private set;
    }

    [field: SerializeField]
    public int Health
    {
        get;
        private set;
    }

    public void Start()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
   
    public void Update()
    {
        playTime += Time.deltaTime;
    }
    
    public void IncreaseCoins()
    {
        scoreCoins++;
        Debug.Log("Coins: " + scoreCoins);
    }
    
    public void IncreaseMaps()
    {
        scoreMaps++;
        Debug.Log("Maps: " + scoreMaps);
        if (scoreMaps == requiredMaps)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
    public void IncreasePotions()
    {
        Health++;
        Debug.Log("Health: " + Health);
    }
    
    public void DecreaseHealth(int decreaseBy)
    {
        Health -= decreaseBy;
        Debug.Log("Health: " + Health);
        if (Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}