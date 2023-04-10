using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject numberCubePrefab;
    public GameObject symbolCylinderPrefab;
    public int minNumber = 1;
    public int maxNumber = 9;
    public int numberOfCubes = 3;

    private int targetNumber;
    private CubeNumber[] numberCubes;
    private CubeSymbols[] symbolCylinders;

    private void Start()
    {
        // Generate random target number
        targetNumber = Random.Range(2, 11);

        // Create number cubes
        numberCubes = new CubeNumber[numberOfCubes];
        for (int i = 0; i < numberOfCubes; i++)
        {
            int randomNumber = Random.Range(minNumber, maxNumber + 1);
            GameObject cubeObj = Instantiate(numberCubePrefab, new Vector3(i, 0, 0), Quaternion.identity);
            CubeNumber cube = cubeObj.GetComponent<CubeNumber>();
            cube.number = randomNumber;
            numberCubes[i] = cube;
        }

        // Create symbol cylinders
        symbolCylinders = new CubeSymbols[numberOfCubes - 1];
        for (int i = 0; i < numberOfCubes - 1; i++)
        {
            char[] symbols = { '+', '-', '*', '/' };
            char randomSymbol = symbols[Random.Range(0, symbols.Length)];
            GameObject cylinderObj = Instantiate(symbolCylinderPrefab, new Vector3(i + 0.5f, 1, 0), Quaternion.identity);
            CubeSymbols cylinder = cylinderObj.GetComponent<CubeSymbols>();
            cylinder.mathSymbol = randomSymbol;
            symbolCylinders[i] = cylinder;
        }
    }
}
