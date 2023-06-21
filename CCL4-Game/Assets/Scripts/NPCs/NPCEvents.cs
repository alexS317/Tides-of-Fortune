using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEvents : MonoBehaviour
{
    // Start is called before the first frame update
    // Play the sound of the footstep based on the animation
    void TreeStep(int number)
    {
        AkSoundEngine.PostEvent("Play_TreeMonsterSound", gameObject);
    }
    
    void GolemStep(int number)
    {
        AkSoundEngine.PostEvent("Play_GolemSteps", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
