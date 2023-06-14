using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DataStorage dataStorage = FindObjectOfType<DataStorage>();

            if (dataStorage.scoreMaps == dataStorage.requiredMaps)
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