using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Global data storage
public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance;

    public float PlayTime { get; private set; }
    public int TotalHealthPotions { get; private set; }
    public int TotalCoins { get; private set; }
    public int TotalMaps { get; private set; }
    public bool KeyFound { get; private set; } = false;
    public int KeyNr { get; private set; } // Only used to display the number in the inventory

    [field: SerializeField] public float PlayerHealth { get; private set; }
    [SerializeField] private float healthPointsPerPotion;
    private float maxHealth;

    public void Start()
    {
        // Ensure only one instance of DataStorage exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Keep the DataStorage object across scenes
        DontDestroyOnLoad(this.gameObject);

        maxHealth = PlayerHealth;
    }

    public void Update()
    {
        // Update playtime every frame
        PlayTime += Time.deltaTime;
    }

    public void IncreaseCoins()
    {
        // Increase the number of collected coins
        TotalCoins++;
        AkSoundEngine.PostEvent("Play_CollectCoin", gameObject);
        Debug.Log("Coins: " + TotalCoins);
    }

    // Increase the number of collected maps
    public void IncreaseTotalMaps()
    {
        TotalMaps++;
        AkSoundEngine.PostEvent("Play_CollectMap", gameObject);
        Debug.Log("Maps: " + TotalMaps);
    }

    // Increase the health after drinking a health potion
    public void IncreasePlayerHealth()
    {
        if (TotalHealthPotions > 0)
        {
            if (PlayerHealth < maxHealth)
                PlayerHealth += healthPointsPerPotion; // Only add health if the player doesn't have max health
            if (PlayerHealth > maxHealth) 
                PlayerHealth = maxHealth; // Prevent health from going over the maximum
            Debug.Log("Health: " + PlayerHealth);
            TotalHealthPotions--;
            AkSoundEngine.PostEvent("Play_DrinkPotion", gameObject);
        }
        else
        {
            Debug.Log("Not enough potions");
        }
    }

    // Increase the number of collected health potions
    public void CollectHealthPotions()
    {
        TotalHealthPotions++;
        AkSoundEngine.PostEvent("Play_CollectPotion", gameObject);
    }

    // Decrease the players health after getting hit by an enemy
    public void DecreasePlayerHealth(float decreaseBy)
    {
        PlayerHealth -= decreaseBy;
        AkSoundEngine.PostEvent("Play_PlayerGotHit", gameObject);
        Debug.Log("Player health: " + PlayerHealth);

        // If health is 0, player dies
        if (PlayerHealth <= 0)
        {
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    // Collects the key that is needed for opening the last chest
    public void CollectKey()
    {
        KeyFound = true;
        KeyNr++;
        AkSoundEngine.PostEvent("Play_CollectKey", gameObject);
        Debug.Log("Congrats, you found the key");
    }
}