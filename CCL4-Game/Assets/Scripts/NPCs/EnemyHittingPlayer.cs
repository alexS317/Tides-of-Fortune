using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHittingPlayer : MonoBehaviour
{
    [SerializeField] private float decreasePlayerHealthBy; 
    private void OnCollisionEnter(Collision collision)
    {

        print("Damage");
        if (collision.gameObject.CompareTag("Player"))
            DataStorage.Instance.DecreaseHealth(decreasePlayerHealthBy);
    }
}
