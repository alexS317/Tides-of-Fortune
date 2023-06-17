using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private float damage;

    public int health = 2;

    //private int points;

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
            print("Player");
            DeadGhost();
            DataStorage.Instance.DecreaseHealth(damage);
        }
       
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        
        if(health <= 0)
        {
            DeadGhost();
            
        }
    }

    

    private void DeadGhost()
    {
        print("BOOOOMM!!!");
        GetComponent<Collider>().enabled = false;
        Instantiate(deathParticels, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }


    
}
