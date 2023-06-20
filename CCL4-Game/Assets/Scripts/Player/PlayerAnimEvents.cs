using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    public static bool IsHitting { get; private set; } = false;

    void HitEnemy(int nr)
    {
        // Triggered when the player's attack animation hits an enemy
        IsHitting = true;
        AkSoundEngine.PostEvent("Play_SwordSwing", gameObject); // Play sword swing sound effect
    }

    void FinishAttack(int nr)
    {
        // Triggered when the player's attack animation finishes
        IsHitting = false;
    }
    
    void FootStep(int side)
    {
        AkSoundEngine.PostEvent("Play_PlayerFootSteps", gameObject);
    }
}