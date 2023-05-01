using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1f;
        
    private Vector3 _movementInput;
    private Rigidbody _rigidbody;
    private BoxCollider _collider;
    
    private bool Grounded()
    {
        RaycastHit hit;
        Ray groundCheck = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheck, out hit, 0.6f))
        {
            if (hit.collider.CompareTag("Ground")) return true;
        }

        return false;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * _movementInput);
    }

    void OnMovement(InputValue value)
    {
        var inputVector = value.Get<Vector2>();
        _movementInput = new Vector3(inputVector.x, 0, inputVector.y);
    }

    void OnRotate(InputValue value)
    {
        var inputVector = value.Get<Vector2>();
        transform.Rotate(0, inputVector.x, 0);
    }

    void OnJump()
    {
        if(Grounded()) _rigidbody.AddForce(jumpForce * Vector3.up);
    }
}
