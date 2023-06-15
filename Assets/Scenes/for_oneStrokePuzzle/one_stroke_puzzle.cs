using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class one_stroke_puzzle : MonoBehaviour
{
    // 육각별(Hexagram) 한붓그리기 게임
    public LineRenderer lineRenderer;
    public Transform player;
    public float minDistance = 0.1f;
    public int vertexCount = 6;

    private bool isDrawing = false;
    private Vector3 lastPosition;
    private int currentVertexCount = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

        if (isDrawing)
        {
            UpdateLineRenderer();
        }
    }

    private void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 1;
        lastPosition = player.position;
        lineRenderer.SetPosition(0, lastPosition);
        currentVertexCount = 1;
    }

    private void StopDrawing()
    {
        isDrawing = false;

        if (currentVertexCount == vertexCount)
        {
            // 육각별이 완성될 때 게임 종료
            Debug.Log("Hexagon completed. Game over!");
        }
    }

    private void UpdateLineRenderer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector3.Distance(lastPosition, mousePosition);

        if (distance > minDistance)
        {
            int currentPosition = lineRenderer.positionCount;
            lineRenderer.positionCount = currentPosition + 1;
            lineRenderer.SetPosition(currentPosition, mousePosition);
            lastPosition = mousePosition;

            currentVertexCount++;
        }
    }
}
