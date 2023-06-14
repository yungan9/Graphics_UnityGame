using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider sphere)
    {
        if(sphere.gameObject.tag == "sphere")
        {
            uiObject.SetActive(true);
        }
    }
}
