using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotionAction : MonoBehaviour
{
    [SerializeField] private ParticleSystem healingVFX;

    // Called when the player drinks the health potion
    void OnHealthPotion()
    {
        // Increase the player's health
        DataStorage.Instance.IncreasePlayerHealth();
        Instantiate(healingVFX, transform.position, Quaternion.identity);
    }
}