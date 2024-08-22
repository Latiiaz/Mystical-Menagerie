using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Change to nodes instead of walk over

    [SerializeField] public int wildBerryCount; 
    [SerializeField] public int shinyMineralCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Foragable"))
        {
            wildBerryCount++;
        }
    }
}
