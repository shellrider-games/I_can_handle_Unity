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
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerAudioManager _audioManager;

    private Transform _cameraTransform;
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
        _cameraTransform = Camera.main.transform;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * _movementInput);
        transform.forward = new Vector3(_cameraTransform.forward.x, 0, _cameraTransform.forward.z);
        UpdateAnimationState();
    }

    void OnMovement(InputValue value)
    {
        var inputVector = value.Get<Vector2>();
        _movementInput = new Vector3(inputVector.x, 0, inputVector.y);
    }

    private void UpdateAnimationState()
    {
        _animator.SetBool("grounded", Grounded());
        _animator.SetBool("walking", _movementInput != Vector3.zero);
    }
    
    void OnJump()
    {
        if (Grounded())
        {
            _rigidbody.AddForce(jumpForce * Vector3.up);
            _audioManager.PostJumpEvent();
        }
    }
}
