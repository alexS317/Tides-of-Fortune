using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage; 
    [SerializeField] private ParticleSystem hitParticles;

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
            // Enemy decreases player health
            Instantiate(hitParticles, transform.position, Quaternion.identity);
            DataStorage.Instance.DecreasePlayerHealth(damage);
        }
    }
}
