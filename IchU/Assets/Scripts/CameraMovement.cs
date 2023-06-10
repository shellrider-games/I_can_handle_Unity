using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float minimumDistanceToTarget;
    [SerializeField] private float maximumDistanceToTarget;

    [SerializeField] private float minimumYOffset;
    [SerializeField] private float maximumYOffset;
    
    [SerializeField] private Vector3 cameraOffset;
    
    
    [SerializeField] private float zoomSpeed = 0.01f;
    [SerializeField] private float rotationSpeed = 0.01f;

    private float _distanceToTarget;
    private float _orbitAngle;

    // Start is called before the first frame update
    void Awake()
    {
        _distanceToTarget = 3f;
    }

    void OnCameraMovement(InputValue value)
    {
        var inputVector = value.Get<Vector2>();
        _orbitAngle -= inputVector.x % 360;
        CameraXRotation(inputVector);
        
    }

    void OnCameraZoom(InputValue value)
    {
        var inputVector = value.Get<Vector2>();
        Zoom(inputVector);
    }

    private void CameraXRotation(Vector2 inputVector)
    {
        cameraOffset.y = Mathf.Clamp(cameraOffset.y + inputVector.y * rotationSpeed, minimumYOffset, maximumYOffset);
    }
    
    private void Zoom(Vector2 inputVector)
    {
        float newDistance = _distanceToTarget - inputVector.y * zoomSpeed;
        if (newDistance >= minimumDistanceToTarget && newDistance <= maximumDistanceToTarget)
            _distanceToTarget = newDistance;
    }
    

    private void Update()
    {
        float radians = Mathf.Deg2Rad * (_orbitAngle-90);
        var x = target.position.x + _distanceToTarget *Mathf.Cos(radians);
        var y = target.position.y + 1.5f + 2 * (_distanceToTarget - minimumDistanceToTarget) /
            (maximumDistanceToTarget - minimumDistanceToTarget);
        var z = target.position.z + _distanceToTarget * Mathf.Sin(radians);
        transform.position = new Vector3(x, y, z);
        transform.LookAt(target.position+new Vector3(Mathf.Cos(radians)*cameraOffset.x, cameraOffset.y, Mathf.Sin(radians)*cameraOffset.z));
    }
}