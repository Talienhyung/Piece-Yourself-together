using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;

    private void Start()
    {
        GenerateGrid();
    }


    void GenerateGrid()
    {
        // Define the position of the first tile
        Vector2 firstTilePosition = new Vector2(-2.234f, -3.204f);

        // Define the offset for each tile
        float xOffset = 0.015f;
        float yOffset = 0.004f;

        // Loop through the grid
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                // Calculate the position of the current tile by adding offsets to the first tile position
                Vector2 tilePosition = firstTilePosition + new Vector2(x * (_tilePrefab.transform.localScale.x + xOffset), y * (_tilePrefab.transform.localScale.y + yOffset));

                // Instantiate the tile at the calculated position
                var spawnedTile = Instantiate(_tilePrefab, tilePosition, Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
            }
        }
    }







    void Update()
    {
        
    }
}
