using System;
using System.Collections;
using System.Collections.Generic;
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
    public float PlayerHealth
    {
        get;
        private set;
    }

    private float maxHealth;

    public void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        DontDestroyOnLoad(this.gameObject);

        maxHealth = PlayerHealth;
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
        if(PlayerHealth < maxHealth) PlayerHealth++;
        Debug.Log("Health: " + PlayerHealth);
    }

    public void DecreaseHealth(float decreaseBy)
    {
        PlayerHealth -= decreaseBy;
        Debug.Log("Health: " + PlayerHealth);
        if (PlayerHealth <= 0)
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