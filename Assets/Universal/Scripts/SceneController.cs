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

    public void Level3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("lvl4");
    }

    public void Level5()
    {
        SceneManager.LoadScene("lvl5");
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