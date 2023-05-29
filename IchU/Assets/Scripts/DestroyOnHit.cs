using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Enemy") || gameObject.CompareTag("Ground")) Destroy(gameObject);
    }
}
