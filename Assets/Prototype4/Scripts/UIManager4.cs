using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager4 : GameBehaviour<UIManager4>
{
    public TMP_Text targetText;
    public TMP_Text number1Text;
    public TMP_Text number2Text;
    public TMP_Text symbolText;
    public TMP_Text answerText;
    
    public TMP_Text scoreText;
    public TMP_Text moneyText;
    public TMP_Text costText;

    public GameObject ingameUIPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        ingameUIPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void UpdateMoney(int _money)
    {
        moneyText.text = "$: " + _money;
    }

    public void UpdateCost(int _cost)
    {
        costText.text = "This will cost $" + _cost;
    }


    public void UpdateTargetText(int _target)
    {
        targetText.text = _target.ToString();
    }

    public void UpdateAnswerText(int _ans)
    {
        answerText.text = _ans.ToString();
    }

    public void UpdateNumber1Text(int _number)
    {
        number1Text.text = _number.ToString();
    }

    public void UpdateNumber2Text(int _number)
    {
        number2Text.text = _number.ToString();
    }

    public void UpdateSymbolText(char _symbol)
    {
        symbolText.text = _symbol.ToString();
    }

    public void OnCorrectAnswer()
    {
        targetText.color = Color.green;
        answerText.color = Color.green;
        ExecuteAfterSeconds(2, () => OnReset());
    }

    public void OnWrongAnswer()
    {
        targetText.color = Color.red;
        answerText.color = Color.red;
        ExecuteAfterSeconds(2, () => OnReset());
    }

    public void OnReset()
    {
        targetText.color = Color.white;
        answerText.color = Color.white;
        answerText.text = "";
    }

    public void OnGameEnd()
    {
        gameOverPanel.SetActive(true);
        ingameUIPanel.SetActive(false);
    }

    public void OnPause()
    {
        pausePanel.SetActive(true);
    }

    public void OnResume()
    {
        pausePanel.SetActive(false);
    }

}
