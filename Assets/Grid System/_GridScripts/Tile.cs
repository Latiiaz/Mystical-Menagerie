using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject _highlightHover;
    [SerializeField] public GameObject _highlightPlayer;

    private void OnMouseEnter()
    {
        _highlightHover.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlightHover.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log(name);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("d");
    //    }
    //}
}
