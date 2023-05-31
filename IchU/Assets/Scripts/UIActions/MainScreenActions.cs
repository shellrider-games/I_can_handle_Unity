using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenActions : MonoBehaviour
{
    public void Start()
    {
        AkSoundEngine.PostEvent("play_menu", gameObject);
    }

    public void StartGame()
    {
        AkSoundEngine.PostEvent("stop_menu", gameObject);
        SceneManager.LoadSceneAsync("Scenes/Level1");
    }
}
