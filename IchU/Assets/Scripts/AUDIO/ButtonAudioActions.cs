using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioActions : MonoBehaviour
{
    public void PlayButtonClick()
    {
        AkSoundEngine.PostEvent("ui_button_click", gameObject);
    }
}
