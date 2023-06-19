using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    

    GameObject sword;
    Transform SwordPosition;

    GameObject hitCollider;

    private BoxCollider weaponCollider;

    private void Start()
    {
        sword = GameObject.FindGameObjectWithTag("Sword");

        hitCollider = GameObject.FindGameObjectWithTag("HitCollider");
        weaponCollider = hitCollider.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        //SwordPosition = sword.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Enemy")
        {
            // other.GetComponent<Ghost>().TakeDamage(damageAmount);
            print("Sword");
            
            DataStorage.Instance.IncreaseCoins();
        }
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

    void ActivateSword()
    {
        GetComponent<Collider>().enabled = true;
    }

    void DeactivateSword()
    {
        GetComponent<Collider>().enabled = false;
    }
}
