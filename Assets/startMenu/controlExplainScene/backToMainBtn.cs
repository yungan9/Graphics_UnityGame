using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMainBtn : MonoBehaviour
{
    public void next()
    {
        SceneManager.LoadScene(0);
    }
}
