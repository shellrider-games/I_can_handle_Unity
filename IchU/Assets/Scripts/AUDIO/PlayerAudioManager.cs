using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private StepEventPoster _stepEventPoster;

    public void Awake()
    {
        _stepEventPoster.OnStepEvent += PostStepEvent;
    }

    public void PostStepEvent()
    {
        AkSoundEngine.PostEvent("step", gameObject);
    }

    public void PostJumpEvent()
    {
        AkSoundEngine.PostEvent("jump", gameObject);
    }
}
