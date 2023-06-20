using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatsUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    private DataStorage storage;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Accessing the storage in parent object
        // (only worked this way because accessing it over instance cause issues with the scaling)
        storage = GetComponentInParent<DataStorage>();
        maxHealth = storage.PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the health bar based on the current player health
        if (DataStorage.Instance.PlayerHealth >= 0 && DataStorage.Instance.PlayerHealth <= maxHealth)
            healthBar.transform.localScale = new Vector3(DataStorage.Instance.PlayerHealth / maxHealth, 1, 1);
    }
}