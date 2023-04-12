using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeNumber : GameBehaviour
{
    public int number;

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

    public CubeNumber(int num)
    {
        number = num;
    }
}
