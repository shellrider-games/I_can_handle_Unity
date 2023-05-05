using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats Instance;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField]
    private Image _healthbarImage;
    [SerializeField]
    private int maxHp = 3;
    

    private int hp;
    private int coins = 0;
    
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
        UpdateCoinText();
    }

    public void Damage()
    {
        if (hp <= 0) return;
        hp--;
        _healthbarImage.fillAmount = hp / (float)maxHp;
    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = $"x {coins}";
    }
}
