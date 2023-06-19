using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPotion : MonoBehaviour
{
    [SerializeField] private float additionalJumpStrength = 5;
    [SerializeField] private float duration = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            StartCoroutine(EnableAdditionalJump(other.gameObject.GetComponent<PlayerMovement>()));
        }
    }

    private IEnumerator EnableAdditionalJump(PlayerMovement playerMovement)
    {
        // Increase the jump strength temporarily
        playerMovement.jumpStrength += additionalJumpStrength;

        // Wait for the specified duration
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the jump strength to its original value
        playerMovement.jumpStrength -= additionalJumpStrength;
    }
}