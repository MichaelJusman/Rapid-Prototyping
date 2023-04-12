using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSymbols : GameBehaviour
{
    public char mathSymbol;

    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCube()
    {
        transform.position = startPos;
        gameObject.SetActive(false);
    }

    public CubeSymbols(char symbol)
    {
        mathSymbol = symbol;
    }
}
