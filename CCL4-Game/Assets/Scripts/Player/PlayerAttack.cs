using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Animator animator;
    [SerializeField] private float damage;

    private BoxCollider weaponCollider;
    private bool isAttacking;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponCollider = weapon.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check boolean from animation event
        if (PlayerAnimEvents.IsHitting)
            weaponCollider.enabled = true;
        else
            weaponCollider.enabled = false;
    }
    
    void OnAttack()
    {
        animator.SetTrigger("attack");  // Trigger automatically resets after the action is complete
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Enemy" or "Ghost" tag
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Enemy hit");
            
            // Get the EnemyStats component from the colliding object
            var enemyStats = other.GetComponent<EnemyStats>();
            
            // Decrease enemy health by the specified damage amount
            enemyStats.TakeDamage(damage);

            // Play the sound event
            AkSoundEngine.PostEvent("Play_PlayerAttack", gameObject);

            if (enemyStats.enemyType == EnemyType.Penguin) AkSoundEngine.PostEvent("Play_PenguinGotHit", gameObject);
        }
    }
}