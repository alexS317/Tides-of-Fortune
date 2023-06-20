using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage; 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Enemy decreases player health
            DataStorage.Instance.DecreasePlayerHealth(damage);  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("AUUUU!!");
            // Enemy decreases player health
            DataStorage.Instance.DecreasePlayerHealth(damage);
        }
    }
}
