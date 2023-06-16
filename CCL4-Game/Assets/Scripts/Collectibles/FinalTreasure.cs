using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTreasure : MonoBehaviour
{
    // Animation event function (wait for animation to complete before loading the scene)
    void FullyOpened(int nr)
    {
        SceneManager.LoadSceneAsync("Success");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only open if the player has the key
        if (DataStorage.Instance.KeyFound)
        {
            GetComponent<Animator>().SetBool("opened", true);
        }
        else Debug.Log("Can't open without a key.");
    }
}