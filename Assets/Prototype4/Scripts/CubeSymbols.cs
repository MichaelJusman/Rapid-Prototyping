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

        gameObject.SetActive(false);
    }

    public void ResetCube()
    {
        transform.position = startPos;
        gameObject.SetActive(true);
    }

    public CubeSymbols(char symbol)
    {
        mathSymbol = symbol;
    }
}
