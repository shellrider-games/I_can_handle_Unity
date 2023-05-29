using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private Image healthbar;
    
    private int hp;

    private void Awake()
    {
        hp = maxHp;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("hit");
        hp -= damage;
        if(hp <= 0) Destroy(gameObject);
        else
        {
            UpdateHealthBar();   
        }
    }

    private void UpdateHealthBar()
    {
        healthbar.fillAmount = hp / (float)maxHp;
    }
}
