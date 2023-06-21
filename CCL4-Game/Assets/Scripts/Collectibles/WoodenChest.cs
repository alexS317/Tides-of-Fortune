using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenChest : MonoBehaviour
{
    public bool Open { get; private set; } = false;

    [SerializeField] private ParticleSystem chestOpenParticles;

    void OpenChest(int nr)
    {
        // Set the Open property to true
        Open = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Play the sound event
            AkSoundEngine.PostEvent("Play_OpenChest", gameObject);
            
            // Triggering the chest opening animation
            this.GetComponent<Animator>().SetBool("opened", true);
            DisableChestCollider();
        }
    }

    public void PlayVFX()
    {
        Instantiate(chestOpenParticles, transform.position, Quaternion.identity);
    }

    private void DisableChestCollider()
    {
        this.GetComponent<Collider>().enabled = false;
    }
}