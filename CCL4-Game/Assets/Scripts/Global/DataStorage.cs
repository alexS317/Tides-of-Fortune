using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance;
    
    public float playTime
    {
        get;
        private set;
    }
    
    [field: SerializeField]
    public int requiredMaps
    {
        get;
        private set;
    }
    
    [field: SerializeField]
    public int requiredKey
    {
        get;
        private set;
    }
    
    public int foundKey
    {
        get;
        private set;
    }
    
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
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
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
    }
    
    public void HealthPotions()
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
    
    public void FoundTreasure()
    {
        if (foundKey == requiredKey)
        {
            SceneManager.LoadScene("Success");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Can't open without a key");
        }
    }
    
    public void Key()
    {
        foundKey++;
        Debug.Log("Congrats, you found the key");
    }
}