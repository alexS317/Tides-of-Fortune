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
        if (other.tag =="Enemy")
        {
            DataStorage.Instance.IncreaseCoins();
        }
    }

    public void ActivatHitBox()
    {
        print("hitbox activate");
        weaponCollider.enabled = true;
    }

    public void DeactivateHitBox()
    {

        print("hitbox deactivat");
        weaponCollider.enabled = false;
    }
}
