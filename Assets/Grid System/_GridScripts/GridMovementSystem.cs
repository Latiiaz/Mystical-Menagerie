using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridMovementSystem : MonoBehaviour
{

    private Vector3 _playerPos;
    
    public float speed = 2.0f;



    [SerializeField] private GridManager _gridManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = transform.position;
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && transform.position == _playerPos)
        {
            _playerPos += Vector3.up;
            //Facing Up
        }
        if (Input.GetKey(KeyCode.S) && transform.position == _playerPos)
        {
            _playerPos += Vector3.down;
            //Facing Down
        }
        if (Input.GetKey(KeyCode.A) && transform.position == _playerPos)
        {
            _playerPos += Vector3.left;
            //Facing Left
        }
        if (Input.GetKey(KeyCode.D) && transform.position == _playerPos)
        {
            _playerPos += Vector3.right;
            //Facing Right
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _playerPos, Time.deltaTime * speed); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GridTile"))
        {
            Debug.Log("d");
        }
    }



    //Use dictionary to store all tile location and possible threats
    //Update when tile has interactions
    //Log all moves in console log 
}
