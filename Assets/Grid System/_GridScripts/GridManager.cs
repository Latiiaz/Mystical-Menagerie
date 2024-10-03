using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    // How many Tiles will spawn
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    private int _tileBorder = 1;

    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _mapBorderTilePrefab;

    // Camera Centering
    [SerializeField] private Transform _cam;


    // Dictionary For Tiles
    //private Dictionary<string, Tile> tileDict= new Dictionary<string, Tile>();

    void Start()
    {
        GenerateBorder();
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
                spawnedTile.name = $"Tile {x}, {y}"; // transform.parent
            }
        }
    }

    void GenerateBorder()
    {
        for (int xb = 0 - _tileBorder; xb < _width + _tileBorder; xb++)
        {
            for (int yb = 0 - _tileBorder; yb < _height + _tileBorder; yb++)
            {
                if (xb == 0 - _tileBorder || xb == _width + _tileBorder || xb == _width|| yb == _height + _tileBorder || xb == _width || yb == _height)
                {
                    var spawnedTile = Instantiate(_mapBorderTilePrefab, new Vector3(xb, yb), Quaternion.identity);
                    spawnedTile.name = $"Tile Border {xb}, {yb}";
                }
            }
        }
    }

    void CameraCentering()
    {
        _cam.transform.position = new Vector3((_width / 2), _height / 2, -10);
    }

    void TileUpdater()
    {

    }
}
