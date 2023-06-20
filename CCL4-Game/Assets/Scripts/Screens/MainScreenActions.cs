using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenActions : MonoBehaviour
{
    public void StartGame()
    {
        // Destroy GlobalData to reset game data
        Destroy(GameObject.Find("GlobalData"));

        // Load Level1
        SceneManager.LoadSceneAsync("Level1");
    }

    public void ExitGame()
    {
        // Quit the game
        Application.Quit();
    }

    public void MainMenu()
    {
        // Load MainMenu
        SceneManager.LoadSceneAsync("MainMenu");
        
        AkSoundEngine.StopAll();    // Stop all sounds so they won't be played over each other
    }

    public void HowToPlay()
    {
        // Load HowToPlay
        SceneManager.LoadSceneAsync("HowToPlay");
    }
}