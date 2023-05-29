using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanForPlayer : MonoBehaviour
{
    public event Action OnPlayerDetected;
    [SerializeField] private float distance;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + distance * transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance))
        {
            if(hit.transform.CompareTag("Player")) OnPlayerDetected?.Invoke();
        }
    }
}
