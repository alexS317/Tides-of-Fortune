using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangePortal : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private int requiredMaps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Can only proceed to next level if enough maps were found in the current one
            if (LevelStorage.Instance.MapsInLevel == requiredMaps)
            {
                SceneManager.LoadSceneAsync(levelName);
            }
            else
            {
                Debug.Log("Please find more maps first.");
            }
        }
    }
}