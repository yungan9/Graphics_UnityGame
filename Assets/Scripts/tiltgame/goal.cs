
using UnityEngine;
using TMPro;

public class goal : MonoBehaviour
{
    [SerializeField]
    private GameObject panelResult;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "goal")
        {
            Destroy(gameObject);
            Debug.Log("Goal");
            panelResult.SetActive(true);
        }
    }
}

