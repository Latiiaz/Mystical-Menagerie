using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBerry : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (audioSource != null)
        //    audioSource.Play();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Picked Up");

            Destroy(gameObject);
        }

    }
}
