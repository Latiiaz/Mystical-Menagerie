using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class NPC : MonoBehaviour, IInteractable
{
    private Transform _playerTransform;

    private const float INTERACT_DISTANCE = 2f; //Change based off distance later

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsWithinInteractDistance()) // F Interact Key
        {
            //interact with this NPC
            Interact();
        }
    }

    public abstract void Interact();


    private bool IsWithinInteractDistance()
    {
        if (Vector2.Distance(_playerTransform.position, transform.position) < INTERACT_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
