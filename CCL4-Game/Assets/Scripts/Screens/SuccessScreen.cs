using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuccessScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    
    // Start is called before the first frame update
    void Start()
    {
        var roundedTime = Math.Round(DataStorage.Instance.playTime, 2);
        time.text = roundedTime.ToString();
    }
}
