using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPassiveSystem : MonoBehaviour
{
    [SerializeField] bool phoenixPassive;
    //[SerializeField] bool carbunclePassive;

    public PlayerMovement playerMovement;

    void Start()
    {
            
    }
    void Update()
    {
        CheckPassives();
    }

    void CheckPassives()
    {
        PhoenixPassive();
    }

    void PhoenixPassive()
    {
        if (phoenixPassive == true)
        {
            playerMovement.moveSpeed = 10;
        }
        else
        {
            playerMovement.moveSpeed = 5;
        }
    }
}
