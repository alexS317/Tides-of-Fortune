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
        if (PlayerAnimEvents.IsHitting) weaponCollider.enabled = true;
        else weaponCollider.enabled = false;
    }
    
    void OnAttack()
    {
        animator.SetTrigger("attack");  // Trigger automatically resets after the action is complete
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Enemy hit");
            var enemyStats = other.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);    // Decrease enemy health
        }
    }
}
