using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (DataStorage.Instance.scoreMaps == DataStorage.Instance.requiredMaps)
            {
                SceneManager.LoadSceneAsync(level);
            }
            else
            {
                Debug.Log("Please find a map first");
            }
        }
    }
}