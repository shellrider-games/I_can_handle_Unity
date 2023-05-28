using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class TakeAttackTrigger : MonoBehaviour
{
    private EnemyHealth _health;
    private void Awake()
    {
        _health = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.CompareTag("Attack"))
        {
            Debug.Log("hit");
            _health.TakeDamage(1);
        }
    }
}
