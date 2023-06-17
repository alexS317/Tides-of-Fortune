using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangePortal : MonoBehaviour
{
    [SerializeField] private string levelName;
    [field:SerializeField] public int RequiredMaps { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Can only proceed to next level if enough maps were found in the current one
            if (LevelStorage.Instance.MapsInLevel == RequiredMaps)
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.Log("Please find more maps first.");
            }
        }
    }
}