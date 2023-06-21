using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ocean : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AkSoundEngine.StopAll();    // Stop all sounds from previous scene
            SceneManager.LoadSceneAsync("GameOver"); // Load the GameOver scene
        }
    }
}