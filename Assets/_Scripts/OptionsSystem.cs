using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSystem : MonoBehaviour
{

    public GameObject optionsMenu;
    public bool menuActivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuOpened();
        }
    }

    private void MenuOpened()
    {
        if (menuActivated)
        {
            Debug.Log("Testing Escape Menu");
            Time.timeScale = 1;
            optionsMenu.SetActive(false);
            menuActivated = false;
        }

        else if (!menuActivated)
        {
            Debug.Log("Escape Menu Close");
            Time.timeScale = 0;
            optionsMenu.SetActive(true);
            menuActivated = true;
        }
    }
}
