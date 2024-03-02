using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBlocks : MonoBehaviour
{
    public GameObject blockPrefab; 
    public Transform spawnPoint; 

    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBlock()
    {
        // Instantiate the blockPrefab at the spawnPoint position and rotation
        Instantiate(blockPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
