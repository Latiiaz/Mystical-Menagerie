using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiritAltar : MonoBehaviour/*, IInteractable*/
{
    //public void Interact()
    //{

    //}
    public GameObject altarSelectionMenu;

    private void Start()
    {
        if (altarSelectionMenu!= null)
        {
            altarSelectionMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            bool isActive = altarSelectionMenu.activeSelf;

            altarSelectionMenu.SetActive(!isActive);

        }
    }
}
