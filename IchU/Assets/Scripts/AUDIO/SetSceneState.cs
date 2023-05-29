using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSceneState : MonoBehaviour
{
    [SerializeField] private string state;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetState("Scene", state);
    }
}
