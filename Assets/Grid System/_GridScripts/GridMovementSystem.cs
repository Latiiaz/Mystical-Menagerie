using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridMovementSystem : MonoBehaviour
{

    public Vector3 playerPos;
    
    public float speed = 2.0f;

    [SerializeField] private GridManager _gridManager;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && transform.position == playerPos)
        {
            playerPos += Vector3.up;
            //Facing Up
        }
        if (Input.GetKey(KeyCode.S) && transform.position == playerPos)
        {
            playerPos += Vector3.down;
            //Facing Down
        }
        if (Input.GetKey(KeyCode.A) && transform.position == playerPos)
        {
            playerPos += Vector3.left;
            //Facing Left
        }
        if (Input.GetKey(KeyCode.D) && transform.position == playerPos)
        {
            playerPos += Vector3.right;
            //Facing Right
        }
        
        transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * speed); 
    }
}
