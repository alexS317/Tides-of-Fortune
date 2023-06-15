using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHittingPlayer : MonoBehaviour
{
    [SerializeField] private int decreasePlayerHealthBy; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            DataStorage.Instance.DecreaseHealth(decreasePlayerHealthBy);
    }
}
