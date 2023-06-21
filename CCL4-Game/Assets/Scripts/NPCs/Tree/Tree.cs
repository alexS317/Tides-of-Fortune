using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    Animator animator;
    public GameObject BerryObject;
    public Transform berryCenter;

    public void ShootBerry()
    {
        print("Eat berries");
        GameObject berry = Instantiate(BerryObject, berryCenter.position, transform.rotation);


        float angleOffset = -8f;
        Vector3 direction = Quaternion.Euler(0f, angleOffset, 0) * transform.forward;

        berry.GetComponent<Rigidbody>().AddForce(direction * 18f, ForceMode.Impulse);

    }
}