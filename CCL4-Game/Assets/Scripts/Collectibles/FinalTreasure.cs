using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTreasure : MonoBehaviour
{
    void FullyOpened(int nr)
    {
        SceneManager.LoadSceneAsync("Success");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DataStorage.Instance.foundKey == DataStorage.Instance.requiredKey)
        {
            this.GetComponent<Animator>().SetBool("opened", true);
        }
        else Debug.Log("Can't open without a key");
    }
}