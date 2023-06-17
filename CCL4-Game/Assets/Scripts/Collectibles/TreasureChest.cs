using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChest : MonoBehaviour
{
    // Event function applied on animation (wait for animation to complete before loading the scene)
    void OpenFinalChest(int nr)
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