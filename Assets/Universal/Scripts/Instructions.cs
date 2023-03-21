using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : GameBehaviour
{
    public GameObject instructionPanel;
    public GameObject ingamePanel;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    public void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        ingamePanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void Page1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
    }

    public void Page2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);
    }

    public void Page3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);
    }

    public void CloseInstructions()
    {
        _GSM.ChangeGameState(GameState.Playing);
        instructionPanel.SetActive(false);
        ingamePanel.SetActive(true);
    }
}
