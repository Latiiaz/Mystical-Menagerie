using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    // Change to nodes instead of walk over

    [SerializeField] public int wildBerryCount;
    private int maxWildBerryCount = 999;

    [SerializeField] public int shinyMineralCount;
    private int maxShinyMineralCount = 999;

    [SerializeField] public int collectedCatsCount;
    private int maxCollectedCatsCount = 9999;

    [SerializeField] public TextMeshProUGUI wildBerryCounter;
    [SerializeField] public TextMeshProUGUI shinyMineralCounter;
    [SerializeField] public TextMeshProUGUI collectedCatsCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wildBerryCounter.text = string.Format("x {0}", wildBerryCount);
        collectedCatsCounter.text = string.Format("x {0}", collectedCatsCount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Foragable"))
        {
            wildBerryCount++;
        }

        if (collision.CompareTag("Cat"))
        {
            collectedCatsCount++;
        }
    }

    void CheckValue()
    {
        if (wildBerryCount > maxWildBerryCount)
        {
            Debug.Log("Max amount of wild berries reached");
            wildBerryCount = 999;
        }

        if (shinyMineralCount > maxShinyMineralCount)
        {
            Debug.Log("Max amount of shiny minerals reached");
            shinyMineralCount = 999;
        }

        if (collectedCatsCount > maxCollectedCatsCount)
        {
            Debug.Log("Max amount of wild berries reached");
            collectedCatsCount = 999;
        }
    }
}
