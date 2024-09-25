using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    // How many Tiles will spawn
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private Tile _tilePrefab;


    // Camera Centering
    [SerializeField] private Transform _cam;

    void Start()
    {
        GenerateGrid();
        CameraCentering();
    }
    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
            }
        }
    }

    void CameraCentering()
    {
        _cam.transform.position = new Vector3((_width / 2), _height / 2, -10);
    }
}
