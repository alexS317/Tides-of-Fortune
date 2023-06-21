using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    [SerializeField] private GameObject healthPotionSlot;
    
    [SerializeField] private GameObject coinSlot;

    [SerializeField] private GameObject mapSlot;

    [SerializeField] private GameObject keySlot;

    private TextMeshProUGUI healthPotionText;
    private TextMeshProUGUI coinText;
    private TextMeshProUGUI mapText;
    private TextMeshProUGUI keyText;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Text field for each collectible
        healthPotionText = healthPotionSlot.GetComponentInChildren<TextMeshProUGUI>();
        coinText = coinSlot.GetComponentInChildren<TextMeshProUGUI>();
        mapText = mapSlot.GetComponentInChildren<TextMeshProUGUI>();
        keyText = keySlot.GetComponentInChildren<TextMeshProUGUI>();

        // Don't show the inventory slots initially
        healthPotionSlot.SetActive(false);
        coinSlot.SetActive(false);
        mapSlot.SetActive(false);
        coinSlot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the inventory slots based on the item count
        ShowIcon(healthPotionSlot, healthPotionText, DataStorage.Instance.TotalHealthPotions);
        ShowIcon(coinSlot, coinText, DataStorage.Instance.TotalCoins);
        ShowIcon(mapSlot, mapText, DataStorage.Instance.TotalMaps);
        ShowIcon(keySlot, keyText, DataStorage.Instance.KeyNr);
    }

    void ShowIcon(GameObject slot, TextMeshProUGUI textField, int itemCount)
    {
        // Show or hide the inventory slot based on the item count
        if (itemCount > 0)
        {
            slot.SetActive(true);
            textField.text = itemCount.ToString();
        }
        else slot.SetActive(false);
    }
}