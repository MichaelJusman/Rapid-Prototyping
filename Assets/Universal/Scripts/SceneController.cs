using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : GameBehaviour<SceneController>
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Proto1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Lvl2");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}