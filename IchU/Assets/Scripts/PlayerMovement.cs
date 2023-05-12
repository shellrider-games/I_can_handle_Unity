using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1f;

    [FormerlySerializedAs("camera")] [SerializeField] private Transform cameraTransform;
        
    private Vector3 _movementInput;
    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    
    private bool Grounded()
    {
        RaycastHit hit;
        Ray groundCheck = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheck, out hit, _collider.height/2 + 0.1f))
        {
            if (hit.collider.CompareTag("Ground")) return true;
        }

        return false;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * _movementInput);
        transform.forward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z);
    }

    void OnMovement(InputValue value)
    {
        var inputVector = value.Get<Vector2>();
        _movementInput = new Vector3(inputVector.x, 0, inputVector.y);
    }
    
    void OnJump()
    {
        if(Grounded()) _rigidbody.AddForce(jumpForce * Vector3.up);
    }
}
