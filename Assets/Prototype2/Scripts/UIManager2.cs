using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : GameBehaviour<UIManager2>
{
    public Slider speedSlider;
    public TMP_Text speedText;
    public float speedValue;

    void Start()
    {
        
    }
    public void Update()
    {
        speedSlider.onValueChanged.AddListener((v) => 
        { speedText.text = v.ToString("F0"); });
        speedSlider.onValueChanged.AddListener((v) =>
        { speedValue = v; });

    }

    public void OnGameEnd()
    {

    }
}
