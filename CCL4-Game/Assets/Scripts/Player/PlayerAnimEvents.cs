using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    public static bool IsHitting { get; private set; } = false;

    void HitEnemy(int nr)
    {
        IsHitting = true;
        // Debug.Log("Hit");
    }

    void FinishAttack(int nr)
    {
        IsHitting = false;
    }
}