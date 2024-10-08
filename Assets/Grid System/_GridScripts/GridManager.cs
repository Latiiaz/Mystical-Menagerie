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

    [SerializeField] private float _maxDurationForTileSpawn;

    // Camera Centering
    [SerializeField] private Transform _cam;

    private float spawnSpeed;
    // Dictionary For Tiles
    //private Dictionary<string, Tile> tileDict= new Dictionary<string, Tile>();

    void Start()
    {
        spawnSpeed = (_maxDurationForTileSpawn / ((_width + _tileBorder+_tileBorder) * (_height + _tileBorder+_tileBorder)));
        Debug.Log(spawnSpeed);
        StartCoroutine(CoolTileSpawning()); 
        CameraCentering();
    }


    void CameraCentering()
    {
        _cam.transform.position = new Vector3((_width / 2), _height / 2, -10);
    }

    void TileUpdater()
    {

    }

    void TileSpawnSpeedCalculator()
    {
        
    }

    IEnumerator CoolTileSpawning()
    {
        

        for (int xb = 0 - _tileBorder; xb < _width + _tileBorder; xb++)
        {
            for (int yb = 0 - _tileBorder; yb < _height + _tileBorder; yb++)
            {
                if (xb == 0 - _tileBorder || xb == _width || yb == _height || yb == 0 - _tileBorder)
                {
                    var spawnedTile = Instantiate(_mapBorderTilePrefab, new Vector3(xb, yb), Quaternion.identity);
                    spawnedTile.name = $"Tile Border {xb}, {yb}";
                    Debug.Log(spawnedTile.name);
                    yield return new WaitForSeconds(spawnSpeed);
                }
            }
        }

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x}, {y}"; // transform.parent
                yield return new WaitForSeconds(spawnSpeed);
            }
        }

    }
}
