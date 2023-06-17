using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHittingPlayer : MonoBehaviour
{
    [SerializeField] private float decreasePlayerHealthBy; 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Damage");
            DataStorage.Instance.DecreasePlayerHealth(decreasePlayerHealthBy);  // Enemy decreases player health
        }
    }
}
