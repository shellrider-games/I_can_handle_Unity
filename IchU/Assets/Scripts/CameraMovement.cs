using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minimumDistanceToTarget;
    [SerializeField] private float maximumDistanceToTarget;
    [SerializeField] private float zoomSpeed = 0.01f;

    private Vector3 _zoomDirection;

    // Start is called before the first frame update
    void Awake()
    {
        _zoomDirection = transform.position.normalized;
    }

    void OnMoveToPlayer(InputValue value)
    {
        var inputVector = value.Get<Vector2>();
        var newPosition = transform.localPosition - (inputVector.y * zoomSpeed * _zoomDirection);
        if (newPosition.magnitude >= minimumDistanceToTarget && newPosition.magnitude <= maximumDistanceToTarget)
            transform.localPosition = newPosition;
    }
}