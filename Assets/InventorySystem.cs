using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject InventoryMenu;
    public bool menuActivated;

    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Debug.Log("Wee Testing Inventory");
            
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            Debug.Log("Wee Testing E");
            
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }


        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("dwa");
        }
    }
}
