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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTargetText(int _target)
    {
        targetText.text = _target.ToString();
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

}
