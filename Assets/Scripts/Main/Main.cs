using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void LoadScene(string sceneName = "outpost with snow")
    {

        SceneManager.LoadScene("outpost with snow");

    }
}
