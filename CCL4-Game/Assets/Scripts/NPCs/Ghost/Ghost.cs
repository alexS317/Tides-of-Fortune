using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // [SerializeField]
    // private float damage;

    // public int health = 2;

    // private int points;

    public ParticleSystem deathParticles;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            DeadGhost();

            // DataStorage.Instance.DecreasePlayerHealth(damage);
        }
    }

    // public void TakeDamage(int damageAmount)
    // {
    //     health -= damageAmount;
    //     
    //     if (health <= 0)
    //     {
    //         DeadGhost();
    //     }
    // }

    private void DeadGhost()
    {
        print("BOOOOMM!!!");

        // Disable the collider of the ghost
        GetComponent<Collider>().enabled = false;

        // Instantiate the deathParticles at the current position with no rotation
        Instantiate(deathParticles, transform.position, Quaternion.identity);

        // Destroy the ghost game object
        Destroy(this.gameObject);
    }
}