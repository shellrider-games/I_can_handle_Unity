using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuburbStartAudio : MonoBehaviour
{
    void Start()
    {
        AkSoundEngine.PostEvent("play_ambience", gameObject);
    }
    
}
