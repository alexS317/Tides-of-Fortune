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

    [SerializeField] 
    private GameObject weapon;

    GameObject  hitCollider;

    private BoxCollider weaponCollider;


    // [SerializeField] private float damage;

    private void Start()
    {
        hitCollider = GameObject.FindGameObjectWithTag("HitCollider");
        weaponCollider = hitCollider.GetComponent<BoxCollider>();
    }

    // Enemy takes damage
    public void TakeDamage(float hitDamage)
    {


        health -= (hitDamage - resistance);

        if (health <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            //Destroy(gameObject);
        }
        
        Debug.Log("Enemy health: " + health);
    }

    public void EnableHitBox()
    {

        print("hitbox activate");
        weaponCollider.enabled = true;
    }

    public void DisableHitBox()
    {

        print("hitbox deactivat");
        weaponCollider.enabled = false;
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         DataStorage.Instance.DecreasePlayerHealth(damage);  // Enemy decreases player health
    //     }
    // }
}