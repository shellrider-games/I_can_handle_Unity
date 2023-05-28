using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepEventPoster : MonoBehaviour
{
    public event Action OnStepEvent;
    
    public void PostStepEvent()
    {
        OnStepEvent?.Invoke();
    }
}
