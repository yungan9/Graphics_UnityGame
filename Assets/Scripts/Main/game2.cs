
using UnityEngine;
using UnityEngine.SceneManagement;

public class game2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "game2")
        {

            Debug.Log("go");
            SceneManager.LoadScene("Grid Game");
        }
    }
}

