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
    public TMP_Text scoreText;
    public TMP_Text answerText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
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

}
