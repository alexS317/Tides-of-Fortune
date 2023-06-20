using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float resistance;
    [SerializeField] Animator animator;


    [SerializeField] ParticleSystem hitParticels;
    [SerializeField] ParticleSystem smashParticles;

    // Enemy takes damage
    public void TakeDamage(float hitDamage)
    {

        Instantiate(hitParticels, transform.position, Quaternion.identity);
        health -= (hitDamage - resistance);

        if (health <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
        }

        Debug.Log("Enemy health: " + health);
    }

    public void PlayHitParticles()
    {
        Instantiate(smashParticles, transform.position, Quaternion.identity );
    }
}