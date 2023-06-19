using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotionAction : MonoBehaviour
{
    void OnHealthPotion()
    {
        DataStorage.Instance.IncreasePlayerHealth();
    }
}