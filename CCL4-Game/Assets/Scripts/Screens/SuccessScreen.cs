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
        var roundedTime = Math.Round(DataStorage.Instance.PlayTime, 2);
        time.text = "Time: " + roundedTime;

        coinScore.text = "Coins: " + DataStorage.Instance.TotalCoins;
    }
}
