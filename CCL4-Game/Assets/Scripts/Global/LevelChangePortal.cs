using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangePortal : MonoBehaviour
{
    [SerializeField] private string levelName;
    [field: SerializeField] public int RequiredMaps { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if enough maps were found in the current level to proceed
            if (LevelStorage.Instance.MapsInLevel == RequiredMaps)
            {
                // Play the sound
                AkSoundEngine.PostEvent("Play_Portal", gameObject);

                // Load the specified level
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.Log("Please find more maps first.");
            }
        }
    }
}