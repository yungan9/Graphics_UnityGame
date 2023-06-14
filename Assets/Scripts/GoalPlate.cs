using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GoalPlate : MonoBehaviour
{
    public GameObject goalolate;

    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider sphere)
    {
        if (sphere.gameObject.tag == "sphere")
        {
            
        }
    }
}