using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScanForPlayer))]
public class DriveOnPlayerDetected : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event carStartEvent;
    [SerializeField] private float acceleration;
    [SerializeField] private float accelerateTo;
    
    private ScanForPlayer _scanForPlayer;
    
    
    private bool _chase = false;
    private float _currentSpeed = 0f;

    private void Awake()
    {
        _scanForPlayer = GetComponent<ScanForPlayer>();
        _scanForPlayer.OnPlayerDetected += Drive;
    }

    private void Drive()
    {
        _scanForPlayer.OnPlayerDetected -= Drive;
        carStartEvent.Post(gameObject, (uint)AkCallbackType.AK_EndOfEvent, StartEngineDone);
    }

    void StartEngineDone(object inCookie, AkCallbackType inType, object inInfo)
    {
        if (inType == AkCallbackType.AK_EndOfEvent)
        {
            _chase = true;
            AkSoundEngine.PostEvent("engine_on", gameObject);
        }
            
    }

    private void Update()
    {
        if (_chase) HandleChase();
        else
        {
            if (_currentSpeed >= 0) HandleBreak();
        }
    }

    private void HandleChase()
    {
        _currentSpeed += acceleration * Time.deltaTime;
        transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
        AkSoundEngine.SetRTPCValue("car_speed", _currentSpeed);

        if (_currentSpeed >= accelerateTo)
        {
            _chase = false;
            AkSoundEngine.PostEvent("engine_off", gameObject);
        }
    }

    private void HandleBreak()
    {
        _currentSpeed -= 2 * acceleration * Time.deltaTime;
        if(_currentSpeed >= 0) {transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);}
    }
}
