using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenActions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Scenes/Level1");
    }
}
