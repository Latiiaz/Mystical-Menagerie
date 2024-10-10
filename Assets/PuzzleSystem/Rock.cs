using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : InteractableObject 
{
    public Rigidbody2D dd;
    // Start is called before the first frame update
    void Start()
    {
        dd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            dd.isKinematic = false;
        }
    }
}
