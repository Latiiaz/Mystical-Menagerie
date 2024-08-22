using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


// Maybe displays spirit icons instead of full stat page. 
// Currently displaying full spirit stat menu
public class SpiritAltar : NonNPCInteractable
{
    // Spirit Altar Object 
    public GameObject altarSelectionMenu;
    public bool menuActivated;
    int timesfed = 0;


    private void Start()
    {
        if (altarSelectionMenu!= null)
        {
            altarSelectionMenu.SetActive(false);
        }
    }
    public override void Interact()
    {
        SpiritMenuUI();
        
    }
    public void SpiritMenuUI()
    {
        if (menuActivated)
        {
            Debug.Log("Wee Testing E");
            Time.timeScale = 1;
            altarSelectionMenu.SetActive(false);
            menuActivated = false;
        }

        else if (!menuActivated)
        {
            Debug.Log("Wee Testing E inv on");
            Time.timeScale = 0;
            altarSelectionMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public void FeedButton()
    {

        timesfed++;

        if (timesfed == 1)
        {
            Debug.Log("One.. More.. Please...");
        }
        if (timesfed == 2)
        {
            Debug.Log("Thank you that was really refreshing");
            timesfed = 0;
        }
    }

}
