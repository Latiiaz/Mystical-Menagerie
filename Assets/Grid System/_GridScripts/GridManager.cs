using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.Timeline;

public class GridManager : MonoBehaviour
{
    [Header("Tile Spawning")]
    // How many Tiles will spawn
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    private int _tileBorder = 1;

    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _mapBorderTilePrefab;

    [SerializeField] private float _maxDurationForTileSpawn;
    private float spawnSpeed;

    [SerializeField] private Transform _borderTileParent; 
    [SerializeField] private Transform _playableTileParent;


    [Header("Camera Controls")]
    // Camera Centering should probably move to camera itself instead of running it here
    [SerializeField] private Transform _cam;


    [Header("Player Spawning")]
    [SerializeField] private GameObject _player;
    [SerializeField] private float _playerSpawnInverval;


    // Dictionary For Tiles
    //private Dictionary<string, Tile> tileDict= new Dictionary<string, Tile>();

    void Start()
    {
        Debug.Log(".");
        _player.SetActive(false);
        StartCoroutine(CoolTileSpawning()); 
        CameraCentering();
    }


    void CameraCentering()
    {
        _cam.transform.position = new Vector3((_width / 2), _height / 2, -10);
    }


    IEnumerator CoolTileSpawning() // Could split player spawning into a different Ienum
    {
        float startTime = Time.time;
        spawnSpeed = (_maxDurationForTileSpawn / ((_width + _tileBorder + _tileBorder) * (_height + _tileBorder + _tileBorder)));
        Debug.Log(spawnSpeed);

        for (int yb = 0 - _tileBorder; yb < _height + _tileBorder; yb++) //Spawns Borders
        {
            for (int xb = 0 - _tileBorder; xb < _width + _tileBorder; xb++)
            {
                if (xb == 0 - _tileBorder || xb == _width || yb == _height || yb == 0 - _tileBorder)
                {
                    var spawnedTile = Instantiate(_mapBorderTilePrefab, new Vector3(xb, yb), Quaternion.identity);
                    spawnedTile.name = $"Tile Border {xb}, {yb}";
                    spawnedTile.transform.SetParent(_borderTileParent);
                    yield return new WaitForSeconds(spawnSpeed);
                }
            }
        }

        for (int x = 0; x < _width; x++) // Spawns Playable Tiles
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x}, {y}";
                spawnedTile.transform.SetParent(_playableTileParent);
                yield return new WaitForSeconds(spawnSpeed);
            }
        }
        Debug.Log(Time.time - startTime);
        
        yield return new WaitForSeconds(_playerSpawnInverval);
       _player.SetActive(true);
    }
}
