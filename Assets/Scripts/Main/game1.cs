
using UnityEngine;
using UnityEngine.SceneManagement;

public class game1 : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "game1")
        {

            Debug.Log("go");
            SceneManager.LoadScene("Tilt Game");
        }
    }
}
