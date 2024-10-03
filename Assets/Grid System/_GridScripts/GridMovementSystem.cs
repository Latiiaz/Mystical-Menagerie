using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridMovementSystem : MonoBehaviour
{

    private Vector3 _playerPos;
    
    public float speed = 2.0f;
    //public float rotateSpeed = 18000f;

    [SerializeField] public GameObject spawnPoint;
    [SerializeField] public GameObject orientationHitBox;

    private BoxCollider2D _boxCollider;
    //[SerializeField] private GridManager _gridManager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawnPointSetter();
        _playerPos = transform.position;
        
        _boxCollider = orientationHitBox.GetComponent<BoxCollider2D>();
    }
    void FixedUpdate() // Need to add: Looking and same input = walk in direction
    {
        if (Input.GetKey(KeyCode.W) && transform.position == _playerPos)
        {
            PlayerRotate(180f);
            
            _playerPos += Vector3.up;
            //Facing Up
        }
        if (Input.GetKey(KeyCode.S) && transform.position == _playerPos)
        {
            PlayerRotate(0f);
            
            _playerPos += Vector3.down;
            //Facing Down
        }
        if (Input.GetKey(KeyCode.A) && transform.position == _playerPos)
        {
            PlayerRotate(270f);
            _playerPos += Vector3.left;
            //Facing Left
        }
        if (Input.GetKey(KeyCode.D) && transform.position == _playerPos)
        {
            PlayerRotate(90f);
            _playerPos += Vector3.right;
            //Facing Right
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _playerPos, Time.deltaTime * speed); 
    }

    void PlayerSpawnPointSetter()
    {
        Vector3 spawnPosition = spawnPoint.transform.position;
        transform.position = spawnPosition;
    }

    void PlayerRotate(float direction)
    {
        transform.rotation = Quaternion.Euler(0f,0f,direction);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GridTile"))
        {
            Debug.Log("Wall");
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BorderTile"))
        {
            Debug.Log("wall");
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BorderTile"))
        {
            Debug.Log("wall");
        }
    }


    //Use dictionary to store all tile location and possible threats
    //Update when tile has interactions
    //Log all moves in console log 

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("GridTile"))
    //    {
    //        Debug.Log("d");
    //    }
    //}
}
