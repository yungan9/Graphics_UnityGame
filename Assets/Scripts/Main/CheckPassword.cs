using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckPassword : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] string pw = "427";
    void Start()
    {
        inputField.text = "";
    }

    public void Update()
    {
        if(inputField.text == pw)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
