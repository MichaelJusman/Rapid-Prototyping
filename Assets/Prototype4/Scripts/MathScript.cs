using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathScript : GameBehaviour<MathScript>
{
    public GameObject brewCheck;
    public int targetNumber;
    public int resultNumber;
    public int minMum = 1;
    public int maxNum = 11;

    public int firstNumber;
    public int secondNumber;
    public char mathSymbol;

    public bool hasBrewed;

    
    // Start is called before the first frame update
    void Start()
    {
        targetNumber = Random.Range(minMum, maxNum);
        _UI4.UpdateTargetText(targetNumber);
        hasBrewed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //    NewTargetNumber();
        //if (Input.GetKeyDown(KeyCode.Space))
        //    Calculate();

        if(targetNumber == resultNumber && hasBrewed)
        {
            _GM4.AddScore(10);
            _GM4.AddMoney(10);
            hasBrewed = false;
            _GM4.OnCorrectAnswer();
            OnReset();
            
        }

        if (targetNumber != resultNumber && hasBrewed)
        {
            _GM4.OnWrongAnswer();
            hasBrewed = false;
        }

    }

    public void NewTargetNumber()
    {
        targetNumber = Random.Range(minMum, maxNum);
        _UI4.UpdateTargetText(targetNumber);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Number1"))
        {
            firstNumber = other.GetComponent<CubeNumber>().number;
            _UI4.UpdateNumber1Text(firstNumber);
            other.GetComponent<CubeNumber>().DisableCube();
        }

        if (other.CompareTag("Number2"))
        {
            secondNumber = other.GetComponent<CubeNumber>().number;
            _UI4.UpdateNumber2Text(secondNumber);
            other.GetComponent<CubeNumber>().DisableCube();
        }

        if (other.CompareTag("Symbol"))
        {
            mathSymbol = other.GetComponent<CubeSymbols>().mathSymbol;
            _UI4.UpdateSymbolText(mathSymbol);
            other.GetComponent<CubeSymbols>().DisableCube();
        }

    }

    public void Calculate()
    {
        if(mathSymbol.ToString() == "-")
        {
            resultNumber = firstNumber - secondNumber;
            _UI4.UpdateAnswerText(resultNumber);
            Debug.Log(firstNumber + " - " + secondNumber + " = " + resultNumber);
        }

        if (mathSymbol.ToString() == "+")
        {
            resultNumber = firstNumber + secondNumber;
            _UI4.UpdateAnswerText(resultNumber);
            Debug.Log(firstNumber + " + " + secondNumber + " = " + resultNumber);
        }

        if (mathSymbol.ToString() == "X")
        {
            resultNumber = firstNumber * secondNumber;
            _UI4.UpdateAnswerText(resultNumber);
            Debug.Log(firstNumber + " * " + secondNumber + " = " + resultNumber);
        }

        hasBrewed = true;
    }

    public void OnReset()
    {
        resultNumber = 0;
        ExecuteAfterSeconds(2, () => NewTargetNumber());
    }
}
