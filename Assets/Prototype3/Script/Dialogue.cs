using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : GameBehaviour<Dialogue>
{
    public GameObject dialoguePanel;
    public GameObject ingamePanel;

    
    // Start is called before the first frame update
    void Start()
    {
        ingamePanel.SetActive(false);
        dialoguePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDialogue()
    {
        _CM3.PlayGameAnimation();
        Debug.Log("im closing");
    }

    public void OnDialogueEnd()
    {
        _GSM.ChangeGameState(GameState.Playing);
        dialoguePanel.SetActive(false);
        ingamePanel.SetActive(true);
    }
}
