using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotionAction : MonoBehaviour
{
    // Called when the player drinks the health potion
    void OnHealthPotion()
    {
        // Increase the player's health
        DataStorage.Instance.IncreasePlayerHealth();
    }
}