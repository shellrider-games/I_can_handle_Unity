using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats Instance;
    [SerializeField]
    private Image _healthbarImage;
    [SerializeField]
    private int maxHp = 3;

    private int hp;
    
    void Awake()
    {
        if (Instance is null) Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        hp = maxHp;
    }

    public void Damage()
    {
        if (hp <= 0) return;
        hp--;
        _healthbarImage.fillAmount = hp / (float)maxHp;
    }
}
