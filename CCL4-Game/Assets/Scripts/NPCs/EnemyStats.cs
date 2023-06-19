using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] 
    private float health;

    [SerializeField]
    private float resistance;

    [SerializeField]
    Animator animator;

    


    // [SerializeField] private float damage;

    private void Start()
    {
        
    }

    // Enemy takes damage
    public void TakeDamage(float hitDamage)
    {
        health -= (hitDamage - resistance);

        print(health);

        if (health <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            //Destroy(gameObject);
        }
        
        Debug.Log("Enemy health: " + health);
    }



    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         DataStorage.Instance.DecreasePlayerHealth(damage);  // Enemy decreases player health
    //     }
    // }
}