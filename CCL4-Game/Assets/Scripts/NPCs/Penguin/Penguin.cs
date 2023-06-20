using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        AkSoundEngine.PostEvent("Play_PenguinSound", gameObject);
    }
}
