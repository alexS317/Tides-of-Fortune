using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    // Start is called before the first frame update
    void Start()
    {
        // Set the SceneLoader instance to this object
        Instance = this;
    }

    public void LoadLevel(string levelName)
    {
        // Load a specific level
        SceneManager.LoadSceneAsync(levelName);
    }
}