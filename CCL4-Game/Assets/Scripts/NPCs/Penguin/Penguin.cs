using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    [SerializeField]
    float health = 4;

    GameObject player;
    Animator animator;
    
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AkSoundEngine.PostEvent("Play_PenguinSound", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        AkSoundEngine.PostEvent("Play_PenguinGotHit", gameObject);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
