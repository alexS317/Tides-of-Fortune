using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private ParticleSystem EndChestOpenParticles;

    void OpenFinalChest(int nr)
    {
        AkSoundEngine.StopAll();
        
        // Load Success scene
        SceneManager.LoadSceneAsync("Success");
    }

    private void OnTriggerEnter(Collider other)
    {

        PlayVFX();
        // Only open if the player has the key
        if (DataStorage.Instance.KeyFound)
        {
            // Play the sound
            AkSoundEngine.PostEvent("Play_OpenChest", gameObject);

            PlayVFX();

            // Set the "opened" parameter in the animator to true
            GetComponent<Animator>().SetBool("opened", true);
        }
        else
        {
            Debug.Log("Can't open without a key.");
        }
    }

    public void PlayVFX()
    {
        Instantiate(EndChestOpenParticles, transform.position, Quaternion.identity);
    }
}