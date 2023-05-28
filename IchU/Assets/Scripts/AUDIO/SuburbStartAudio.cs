using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuburbStartAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("suburb_ambience", gameObject);
    }
    
}
