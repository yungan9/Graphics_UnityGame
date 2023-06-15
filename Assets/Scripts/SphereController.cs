using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    public Text winText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GoalPlate"))
        {
            winText.text = "Goal Reached!";
        }
    }
}
