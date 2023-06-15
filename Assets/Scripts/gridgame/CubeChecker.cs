using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner cubeSpawner;
    private CubeController[] touchCubes;

    private int correctCount = 0;
    private int incorrectCount = 0;

    public int CorrectCount
    {
        set => correctCount = Mathf.Max(0,value);
        get => correctCount;
    }
    public int IncorrectCount
    {
        set => incorrectCount = Mathf.Max(0,value);
        get => incorrectCount;
    }

    private void Awake()
    {
        touchCubes = GetComponentsInChildren<CubeController>();
        for(int i = 0; i < touchCubes.Length; ++i)
        {
            touchCubes[i].Setup(cubeSpawner, this);
        }
    }

    private void Update()
    {
        if (CorrectCount + IncorrectCount == touchCubes.Length)
        {
            if (incorrectCount == 0)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }

            CorrectCount = 0;
            IncorrectCount = 0;
        }
    }
}
