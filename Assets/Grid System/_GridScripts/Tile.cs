using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject _highlightClick;
    //[SerializeField] public GameObject _highlightPlayer;

    //private void OnMouseEnter()
    //{
    //    _highlightHover.SetActive(true);
    //}

    //private void OnMouseExit()
    //{
    //    _highlightHover.SetActive(false);
    //}

    private void OnMouseDown()
    {
        //_highlightClick.SetActive(true);
        Debug.Log(name);

    }


    // Delete Tiles for reset
    public void DeleteSelf()
    {
        Destroy(gameObject,1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeleteSelf();
        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.CompareTag("Player"))
        //    {
        //        Debug.Log("d");
        //    }
        //}
    }

        //private void OnC(Collision2D collision)
        //{
        //    if (collision.gameObject.CompareTag("GridTile"))
        //    {
        //    Debug.Log("hit");
        //    }
        //}

    private void OntriggerStay2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Debug.Log("hit");
        }
    }
}
