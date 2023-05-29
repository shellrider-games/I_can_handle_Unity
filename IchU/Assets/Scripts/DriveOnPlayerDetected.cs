using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScanForPlayer))]
public class DriveOnPlayerDetected : MonoBehaviour
{
    private ScanForPlayer _scanForPlayer;
    private void Awake()
    {
        _scanForPlayer = GetComponent<ScanForPlayer>();
        _scanForPlayer.OnPlayerDetected += Drive;
    }

    private void Drive()
    {
        _scanForPlayer.OnPlayerDetected -= Drive;
        object cookie = new object();
        AkSoundEngine.PostEvent("car_start", gameObject);
    }

    void StartEngineDone(object inCookie, AkCallbackType inType, object inInfo)
    {
        if(inType == AkCallbackType.AK_EndOfEvent) Debug.Log("start over");
    }
}
