using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // DataStorage.instance.FoundTreasure();
            
            this.GetComponent<Animator>().SetBool("opened", true);
        }
    }
}
