using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBoi : GameBehaviour
{
    public GameObject dialoguePanel;
    public GameObject ingameSpeechPanel;

    public GameObject page1;
    public GameObject page2;
    public GameObject page2Alt;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;

    public TMP_Text boxBoiSpeech;
    
    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(true);
        ingameSpeechPanel.SetActive(false);
        page1.SetActive(true);
        page2.SetActive(false);
        page2Alt.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        boxBoiSpeech.text = "Hey you, pick me up!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Page2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page2Alt.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        boxBoiSpeech.text = "Great, I need your help!";
    }

    public void Page2Alt()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page2Alt.SetActive(true);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        boxBoiSpeech.text = "boxboi is not familiar with the concept of consent. You will help me!";
    }

    public void Page3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page2Alt.SetActive(false);
        page3.SetActive(true);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(false);
        boxBoiSpeech.text = "look at those red tubes, they are my buddies infected with a virus";
    }

    public void Page4()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page2Alt.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(true);
        page5.SetActive(false);
        page6.SetActive(false);
        boxBoiSpeech.text = "I can cure them by shooting them with antivirus orb, you can aim me using the mouse";
    }

    public void Page5()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page2Alt.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(true);
        page6.SetActive(false);
        boxBoiSpeech.text = "Do you know how to move? WASD, duh! Also, space to jump, don’t fall!";
    }

    public void Page6()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page2Alt.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        page6.SetActive(true);
        boxBoiSpeech.text = "Cure all of my friends and use the portal to get to the planet surface!";
    }

    public void StartGame()
    {
        dialoguePanel.SetActive(false);
        ingameSpeechPanel.SetActive(true);

    }
}
