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
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemyActions = other.GetComponent<EnemyActions>();
            enemyActions.TakeDamage(damage);    // Decrease enemy health
        }

        // Just for testing purposes
        // if (other.gameObject.CompareTag("Ghost"))
        // {
        //     other.GetComponent<Ghost>().TakeDamage((int)damage);
        // }
    }
}
