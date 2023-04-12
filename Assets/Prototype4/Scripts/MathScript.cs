using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathScript : GameBehaviour<MathScript>
{
    public GameObject brewCheck;
    public int targetNumber;
    public int minMum = 1;
    public int maxNum = 11;

    public int firstNumber;
    public int secondNumber;
    public char mathSymbol;

    
    // Start is called before the first frame update
    void Start()
    {
        targetNumber = Random.Range(minMum, maxNum);
        _UI4.UpdateTargetText(targetNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            NewTargetNumber();
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
            Destroy(other);
        }

        if (other.CompareTag("Number2"))
        {
            secondNumber = other.GetComponent<CubeNumber>().number;
            _UI4.UpdateNumber2Text(secondNumber);
            Destroy(other);
        }

        if (other.CompareTag("Symbol"))
        {
            mathSymbol = other.GetComponent<CubeSymbols>().mathSymbol;
            _UI4.UpdateSymbolText(mathSymbol);
            Destroy(other);
        }

    }
}
