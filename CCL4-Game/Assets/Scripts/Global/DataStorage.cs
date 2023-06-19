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
        AkSoundEngine.PostEvent("Play_CollectCoin", gameObject);
        Debug.Log("Coins: " + TotalCoins);
    }

    public void IncreaseTotalMaps()
    {
        TotalMaps++;
        AkSoundEngine.PostEvent("Play_CollectMap", gameObject);
        Debug.Log("Maps: " + TotalMaps);
    }

    public void IncreasePlayerHealth()
    {
        if (TotalHealthPotions > 0)
        {
            if (PlayerHealth < maxHealth) PlayerHealth++; // Only add health if the player doesn't have max health
            Debug.Log("Health: " + PlayerHealth);
            TotalHealthPotions--;
            AkSoundEngine.PostEvent("Play_DrinkPotion", gameObject);
        }
        else Debug.Log("Not enough potions");
    }

    public void CollectHealthPotions()
    {
        TotalHealthPotions++;
    }

    public void DecreasePlayerHealth(float decreaseBy)
    {
        PlayerHealth -= decreaseBy;
        Debug.Log("Player health: " + PlayerHealth);

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
        AkSoundEngine.PostEvent("Play_CollectKey", gameObject);
        Debug.Log("Congrats, you found the key");
    }
}