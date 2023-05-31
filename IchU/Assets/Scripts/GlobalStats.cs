using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats Instance;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image _healthbarImage;
    [SerializeField] private int maxHp = 3;
    [SerializeField] private GameObject uiCanvas;

    private PlayerAudioManager _playerAudioManager;
    

    private int hp;
    private int coins = 0;

    private int coinPickupRTPC = 0;
    private IEnumerator coinCountdownCoroutine;
    
    void Awake()
    {
        if (Instance is null) Instance = this;
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += UpdatePlayerAudioMangerReference;
    }

    private void UpdatePlayerAudioMangerReference(Scene _, LoadSceneMode __)
    {
        _playerAudioManager = FindObjectOfType<PlayerAudioManager>();
    }
    
    private void Start()
    {
        hp = maxHp;
        UpdateCoinText();
        AkSoundEngine.PostEvent("play_ambience", gameObject);
    }

    public void Damage()
    {
        
        hp--;
        _healthbarImage.fillAmount = hp / (float)maxHp;
        if (_playerAudioManager is not null) _playerAudioManager.PostHurtEvent();
        if (hp <= 0)
        {
            uiCanvas.SetActive(false);
            AkSoundEngine.PostEvent("stop_ambience", gameObject);
            SceneManager.LoadSceneAsync("GameOver");
        }

    }

    public void RestartGame()
    {
        hp = maxHp;
        _healthbarImage.fillAmount = hp / (float)maxHp;
        coins = 0;
        UpdateCoinText();
        coinPickupRTPC = 0;
        uiCanvas.SetActive(true);
        AkSoundEngine.PostEvent("play_ambience", gameObject);
        SceneManager.LoadScene("Level1");
    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinText();
        HandleCoinAudio();
    }

    private void HandleCoinAudio()
    {
        if (coinCountdownCoroutine is not null)
        {
            StopCoroutine(coinCountdownCoroutine);
        }

        AkSoundEngine.PostEvent("pu_coin", gameObject);
        AkSoundEngine.SetRTPCValue("coin_pickup_shift", coinPickupRTPC);
        coinPickupRTPC = Math.Clamp(coinPickupRTPC + 1, 0, 20);
        coinCountdownCoroutine = coinPickupZero();
        StartCoroutine(coinCountdownCoroutine);
    }

    private IEnumerator coinPickupZero()
    {
        yield return new WaitForSeconds(5);
        coinPickupRTPC = 0;
    }
    
    private void UpdateCoinText()
    {
        coinText.text = $"x {coins}";
    }
}
