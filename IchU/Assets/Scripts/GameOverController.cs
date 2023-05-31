using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void Start()
    {
        AkSoundEngine.PostEvent("play_game_over", gameObject);
    }

    public void RestartGame()
    {
        AkSoundEngine.PostEvent("stop_game_over", gameObject);
        GlobalStats.Instance.RestartGame();
    }
}
