using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour
{
    public static DataStorage instance;
    
    public float playTime
    {
        get;
        private set;
    }

    public void Start()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
   
    public void Update()
    {
        playTime += Time.deltaTime;
    }

    
}