using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuccessScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI coinScore;
    
    // Start is called before the first frame update
    void Start()
    {
        // Display the rounded play time on the success screen
        var roundedTime = Math.Round(DataStorage.Instance.PlayTime, 2);
        time.text = "Time: " + roundedTime + "s";

        // Display the total coin score on the success screen
        coinScore.text = "Coins: " + DataStorage.Instance.TotalCoins;
    }
}
