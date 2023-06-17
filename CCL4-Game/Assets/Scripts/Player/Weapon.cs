using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damageAmount = 2;

    GameObject sword;
    Transform SwordPosition;

    private void Start()
    {
        sword = GameObject.FindGameObjectWithTag("Sword");
    }

    private void Update()
    {
        //SwordPosition = sword.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Ghost")
        {
            // other.GetComponent<Ghost>().TakeDamage(damageAmount);
            print("Sword");
            
            DataStorage.Instance.IncreaseCoins();
        }
    }

    void ActivateSword()
    {
        GetComponent<Collider>().enabled = true;
    }

    void DeactivateSword()
    {
        GetComponent<Collider>().enabled = false;
    }
}
