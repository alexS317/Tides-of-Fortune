using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damage;

    // Enemy takes damage
    public void TakeDamage(float hitDamage)
    {
        health -= hitDamage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
        Debug.Log("Enemy health: " + health);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DataStorage.Instance.DecreasePlayerHealth(damage);  // Enemy decreases player health
        }
    }
}