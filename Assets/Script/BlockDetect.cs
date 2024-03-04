using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetect : MonoBehaviour
{
    public GameObject block;

    void Update()
    {
        Vector3 center = block.transform.position;

        float spacing = 0.2f;

        List<Vector3> blockPositions = new List<Vector3>();

        blockPositions.Add(center + new Vector3(spacing, 0f, 0f)); // Bloc à droite du centre
        blockPositions.Add(center + new Vector3(-spacing, 0f, 0f)); // Bloc à gauche du centre
        blockPositions.Add(center + new Vector3(0f, 0f, spacing)); // Bloc devant le centre
        blockPositions.Add(center + new Vector3(0f, 0f, -spacing)); // Bloc derrière le centre

        foreach (Vector3 position in blockPositions)
        {
            Debug.Log("Position du bloc : " + position);
        }
    }
}
