using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenChest : MonoBehaviour
{
    public bool Open { get; private set; } = false;

    void OpenChest(int nr)
    {
        Open = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<Animator>().SetBool("opened", true);
            // Open = true;
        }
    }
}