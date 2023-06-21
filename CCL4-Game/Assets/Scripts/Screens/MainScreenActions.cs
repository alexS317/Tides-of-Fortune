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
        
        AkSoundEngine.StopAll();    // Stop all sounds so they won't be played over each other
        AkSoundEngine.PostEvent("Play_Button", gameObject);

        // Load Level1
        SceneManager.LoadSceneAsync("Level1");
    }

    public void ExitGame()
    {
        AkSoundEngine.PostEvent("Play_Button", gameObject);
        // Quit the game
        Application.Quit();
    }

    public void MainMenu()
    {
        AkSoundEngine.StopAll();    // Stop all sounds so they won't be played over each other
        AkSoundEngine.PostEvent("Play_Button", gameObject);
        
        // Load MainMenu
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void HowToPlay()
    {
        AkSoundEngine.PostEvent("Play_Button", gameObject);
        // Load HowToPlay
        SceneManager.LoadSceneAsync("HowToPlay");
    }
}