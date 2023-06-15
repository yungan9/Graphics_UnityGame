using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private Color[] cubeColors;
    public Color[] CubeColors => cubeColors;

    [SerializeField]
    private GameObject cubesetPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float spawnTime = 1.0f;

    private void Awake()
    {
        StartCoroutine("SpawnCubeSet");
    }

    private IEnumerator SpawnCubeSet()
    {
        while (true)
        {
            GameObject clone = Instantiate(cubesetPrefab, spawnPoint.position, Quaternion.identity);
            MeshRenderer[] renderers = clone.GetComponentsInChildren<MeshRenderer>();

            for (int i = 0; i < renderers.Length; ++i)
            {
                int index = Random.Range(0, CubeColors.Length);
                renderers[i].material.color = cubeColors[index];

            }
            yield return new WaitForSeconds(spawnTime);
        }
    }

}
