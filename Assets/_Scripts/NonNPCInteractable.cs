using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Eventually will replace "NPC.cs" if too many uses NPC. Replaced

public abstract class NonNPCInteractable : MonoBehaviour, IInteractable
{
    private Transform _playerTransform;

    private const float INTERACT_DISTANCE = 2f; //Change based off distance later

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // E Interact Key..  Note: NPC is F, Objects are E, Distance Check not working
        {
            //interact with this NonNPC
            
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
