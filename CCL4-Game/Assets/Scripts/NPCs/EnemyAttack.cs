using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage; 
    [SerializeField] private ParticleSystem hitParticles;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("AUUUU!!");
            // Enemy decreases player health
            Instantiate(hitParticles, transform.position, Quaternion.identity);
            DataStorage.Instance.DecreasePlayerHealth(damage);
        }
    }
}
