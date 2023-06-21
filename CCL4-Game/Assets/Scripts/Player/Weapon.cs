using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameObject hitCollider;
    [SerializeField]
    Collider weaponCollider;

    private void Start()
    {
        //hitCollider = GameObject.FindGameObjectWithTag("HitCollider");
       // weaponCollider = hitCollider.GetComponent<Collider>();
        
    }

    private void Update()
    {
        //SwordPosition = sword.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is tagged as "Enemy"
        if (other.tag =="Enemy")
        {
            // Increase the Killcount
            DataStorage.Instance.IncreaseKillCount();
        }
    }

    // Activate the weapon's hitbox collider
    public void ActivatHitBox()
    {
        print("hitbox activate");
        weaponCollider.enabled = true;
    }

    // Deactivate the weapon's hitbox collider
    public void DeactivateHitBox()
    {

        print("hitbox deactivat");
        weaponCollider.enabled = false;
    }
}
