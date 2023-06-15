using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnBtn : MonoBehaviour
{
    public void returnMain()
    {
        SceneManager.LoadScene(1);
    }
}
