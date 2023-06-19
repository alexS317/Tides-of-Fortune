using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    Animator animator;

    public GameObject BerryObject;
    public Transform berryCenter;


    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBerry()
    {
        print("Eat berries");
        GameObject berry = Instantiate(BerryObject, berryCenter.position, transform.rotation );
        berry.GetComponent<Rigidbody>().AddForce(transform.forward * 18f, ForceMode.Impulse);
    }
}
