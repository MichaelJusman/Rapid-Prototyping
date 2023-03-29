using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : GameBehaviour<Dialogue>
{
    public GameObject dialoguePanel;
    public GameObject ingamePanel;
    public GameObject hatePanel;

    public GameObject warningText;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    
    // Start is called before the first frame update
    void Start()
    {
        ingamePanel.SetActive(false);
        dialoguePanel.SetActive(true);
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        hatePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDialogue()
    {
        _CM3.PlayGameAnimation();
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        hatePanel.SetActive(true);
        warningText.SetActive(false);
        Debug.Log("im closing");
    }

    public void OnDialogueEnd()
    {
        _GSM.ChangeGameState(GameState.Playing);
        dialoguePanel.SetActive(false);
        ingamePanel.SetActive(true);
    }

    public void Page1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        hatePanel.SetActive(false);
    }

    public void PrickEnter()
    {
        warningText.SetActive(true);
    }

    public void PrickExitr()
    {
        warningText.SetActive(false);
    }

    public void Page2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);
        hatePanel.SetActive(false);
    }

    public void Page3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);
        hatePanel.SetActive(false);
    }
}
