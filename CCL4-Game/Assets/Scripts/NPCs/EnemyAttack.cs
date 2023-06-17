using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage; 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Attack player");
            DataStorage.Instance.DecreasePlayerHealth(damage);  // Enemy decreases player health
        }
    }
}
