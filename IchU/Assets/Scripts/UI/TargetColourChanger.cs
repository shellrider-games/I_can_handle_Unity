using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TargetColourChanger : MonoBehaviour
{
    private Image _targetImage;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color enemyDetectedColor;

    private void Awake()
    {
        _targetImage = GetComponent<Image>();
        _targetImage.color = defaultColor;
    }

    void FixedUpdate()
    {
        if (EnemyDetected())
        {
            _targetImage.color = enemyDetectedColor;
        }
        else
        {
            _targetImage.color = defaultColor;
        }    
    }
    
    private bool EnemyDetected()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
        {
            return hit.transform.CompareTag("Enemy");
        }

        return false;
    }
}