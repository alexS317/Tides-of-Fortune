using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject coinSlot;

    [SerializeField] private GameObject mapSlot;

    [SerializeField] private GameObject keySlot;

    // Start is called before the first frame update
    void Start()
    {
        coinSlot.SetActive(false);
        mapSlot.SetActive(false);
        coinSlot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowIcon(coinSlot, DataStorage.Instance.TotalCoins);
        ShowIcon(mapSlot, DataStorage.Instance.TotalMaps);
        ShowIcon(keySlot, DataStorage.Instance.KeyNr);
    }

    void ShowIcon(GameObject slot, int itemCount)
    {
        if (itemCount > 0)
        {
            slot.SetActive(true);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = itemCount.ToString();
        }
        else slot.SetActive(false);
    }
}