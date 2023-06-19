using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenActions : MonoBehaviour
{
    public void StartGame()
    {
        Destroy(GameObject.Find("GlobalData"));
        
        SceneManager.LoadSceneAsync("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}