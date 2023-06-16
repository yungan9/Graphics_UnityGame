
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private GameObject PanelResult;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube")
        {
            
            Debug.Log("go");
            PanelResult.SetActive(true);
        }
    }
}