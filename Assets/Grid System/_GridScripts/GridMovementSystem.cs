using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;

public class GridMovementSystem : MonoBehaviour
{

    private Vector3 _playerPos;
    
    public float speed = 2.0f;

    [SerializeField] public GameObject spawnPoint;
    [SerializeField] public GameObject orientationHitBox;

    private BoxCollider2D _boxCollider;
    [SerializeField] private GridManager _gridManager;

    [SerializeField] bool isMovable = false; //Will be referencing this a lot to ensure the player doesnt move weirdly (turning, spawning, impt scenes)

    [SerializeField] bool lookRight = false;
    [SerializeField] bool lookLeft = false;
    [SerializeField] bool lookUp = false;
    [SerializeField] bool lookDown = false;


    private ActionsKeeper _actionsKeeper;

    [SerializeField] private int _steps = 1;
    [SerializeField] private float _actionInterval;


    void Awake()
    {
        _actionsKeeper = FindObjectOfType<ActionsKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawnPointSetter();
        _playerPos = transform.position;
        _boxCollider = orientationHitBox.GetComponent<BoxCollider2D>();


    }
    void FixedUpdate() // Need to add: Looking and same input = walk in direction
    {


        PlayerLookingDirection();
        
    }

    void PlayerSpawnPointSetter()
    {
        Vector3 spawnPosition = spawnPoint.transform.position;
        transform.position = spawnPosition;
    }

    void PlayerLookingDirection()
    {
        StartCoroutine(CooldownPerAction());

        if (Input.GetKey(KeyCode.W) && transform.position == _playerPos)
        {
            
            if (lookUp)
            {
                Debug.Log("Up");
                _playerPos += Vector3.up;
                _actionsKeeper.ModifyScore(_steps);
            }
            else
            {
                PlayerRotate(180f);
            }
            //Facing Up
        }
        if (Input.GetKey(KeyCode.S) && transform.position == _playerPos)
        {
            if (lookDown)
            {
                Debug.Log("Down");
                _playerPos += Vector3.down;
                _actionsKeeper.ModifyScore(_steps);
            }
            else
            {
                PlayerRotate(0f);
            }
            //Facing Down
        }
        if (Input.GetKey(KeyCode.A) && transform.position == _playerPos)
        {
            if (lookLeft)
            {
                Debug.Log("Left");
                _playerPos += Vector3.left;
                _actionsKeeper.ModifyScore(_steps);
            }
            else
            {
                PlayerRotate(270f);
            }
            //Facing Left
        }
        if (Input.GetKey(KeyCode.D) && transform.position == _playerPos)
        {
            if (lookRight)
            {
                Debug.Log("Right");
                _playerPos += Vector3.right;
                _actionsKeeper.ModifyScore(_steps);
            }
            else
            {
                PlayerRotate(90f);
            }
            //Facing Right
        }

       
        transform.position = Vector3.MoveTowards(transform.position, _playerPos, Time.deltaTime * speed); 
    }
    void PlayerRotate(float direction)
    {
        PlayerDirectionReset();
        transform.rotation = Quaternion.Euler(0f,0f,direction);

        if (direction == 0f)
        {
            lookDown = true;
        }
        if (direction == 90f)
        {
            lookRight = true;
        }
        if (direction == 180f)
        {
            lookUp = true;
        }
        if (direction == 270f)
        {
            lookLeft = true;
        }

    }
    void PlayerDirectionReset()
    {
        lookUp = false;
        lookDown = false;
        lookLeft = false;
        lookRight = false;     
    }
    void ClampPlayer() // clamp to border
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BorderTile"))
        {
            Debug.Log("Wall");
        }
    }
    IEnumerator CooldownPerAction()
    {
        yield return new WaitForSeconds(_actionInterval);
    }

}
