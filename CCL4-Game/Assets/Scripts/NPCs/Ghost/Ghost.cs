using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    private void Start()
    {
        AkSoundEngine.PostEvent("Play_GhostSound", gameObject);
    }

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