using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Combination : MonoBehaviour
{
    public CubeNumber[] cubes;
    public CubeSymbols[] symbols;

    public Combination(CubeNumber[] numCubes, CubeSymbols[] symCylinders)
    {
        cubes = numCubes;
        symbols = symCylinders;
    }

    public int GetValue()
    {
        int value = cubes[0].number;
        for (int i = 1; i < cubes.Length; i++)
        {
            switch (symbols[i - 1].mathSymbol)
            {
                case '+':
                    value += cubes[i].number;
                    break;
                case '-':
                    value -= cubes[i].number;
                    break;
                case '*':
                    value *= cubes[i].number;
                    break;
                case '/':
                    value /= cubes[i].number;
                    break;
            }
        }
        return value;
    }
    public bool IsValid()
    {
        return cubes.Length >= 2 && symbols.Length == cubes.Length - 1
               && symbols.All(s => "+-*/".Contains(s.mathSymbol));
    }

    //public void CheckCombination()
    //{
    //    int result = CubeNumber[0].number;
    //    for (int i = 0; i < CubeSymbols.Length; i++)
    //    {
    //        char symbol = symbolCylinders[i].mathSymbol;
    //        int nextNumber = numberCubes[i + 1].number;
    //        switch (symbol)
    //        {
    //            case '+':
    //                result += nextNumber;
    //                break;
    //            case '-':
    //                result -= nextNumber;
    //                break;
    //            case '*':
    //                result *= nextNumber;
    //                break;
    //            case '/':
    //                result /= nextNumber;
    //                break;
    //        }
    //    }

    //    if (result == targetNumber)
    //    {
    //        Debug.Log("You win!");
    //    }
    //    else
    //    {
    //        Debug.Log("Try again.");
    //    }
    //}
}
