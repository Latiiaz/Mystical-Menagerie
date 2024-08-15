using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPassiveSystem : MonoBehaviour
{
    [SerializeField] bool phoenixPassive;
    [SerializeField] bool carbunclePassive;

    public PlayerMovement playerMovement;

    void Start()
    {
            
    }
    private void Update()
    {
        CheckPassives();
    }

    void CheckPassives()
    {
        PhoenixPassive();
        if (carbunclePassive == true)
        {
            CarbunclePassive();
        }
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

    void CarbunclePassive()
    {
        Debug.Log("Carbuncle Passive Activated");
    }
}
