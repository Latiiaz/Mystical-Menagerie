using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPassiveSystem : MonoBehaviour
{
    [SerializeField] bool phoenixPassive;
    [SerializeField] bool carbunclePassive;

    private void Update()
    {
        CheckPassives();
    }

    void CheckPassives()
    {
        if (phoenixPassive == true)
        {
            PhoenixPassive();
        }

        if (carbunclePassive == true)
        {
            CarbunclePassive();
        }
    }

    void PhoenixPassive()
    {
        Debug.Log("Phoenix Passive Activated");
    }

    void CarbunclePassive()
    {
        Debug.Log("Carbuncle Passive Activated");
    }
}
