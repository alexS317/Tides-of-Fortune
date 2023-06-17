using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Global data storage
public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance;

    public float PlayTime { get; private set; }

    public int TotalCoins { get; private set; }

    public int TotalMaps { get; private set; }

    public bool KeyFound { get; private set; } = false;
    
    public int KeyNr { get; private set; }  // Only used to display the number in the inventory

    [field: SerializeField] public float PlayerHealth { get; private set; }

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
        PlayTime += Time.deltaTime;
    }

    public void IncreaseCoins()
    {
        TotalCoins++;
        Debug.Log("Coins: " + TotalCoins);
    }

    public void IncreaseTotalMaps()
    {
        TotalMaps++;
        Debug.Log("Maps: " + TotalMaps);
    }

    public void IncreasePlayerHealth()
    {
        if (PlayerHealth < maxHealth) PlayerHealth++; // Only add health if the player doesn't have max health
        Debug.Log("Health: " + PlayerHealth);
    }

    public void DecreasePlayerHealth(float decreaseBy)
    {
        PlayerHealth -= decreaseBy;
        Debug.Log("Health: " + PlayerHealth);

        // If health is 0, player dies
        if (PlayerHealth <= 0)
        {
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    public void CollectKey()
    {
        KeyFound = true;
        KeyNr++;
        Debug.Log("Congrats, you found the key");
    }
}