using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private float damage;

    public ParticleSystem deathParticels;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.CompareTag("Player"))
        {
            print("BOOOOMM!!!");

            Instantiate(deathParticels, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
            DataStorage.Instance.DecreaseHealth(damage);
            
        }
            
        
    }
}
