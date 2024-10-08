using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private Vector3 _initPos;

    [SerializeField] private GameObject _northBox;
    [SerializeField] private GameObject _southBox;
    [SerializeField] private GameObject _eastBox;
    [SerializeField] private GameObject _westBox;



    void Start()
    {
        _initPos = transform.position;


        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d != null)
        {
            rb2d.isKinematic = true;
        }
        else
        {
            Debug.LogError("It failed...");
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _initPos, Time.deltaTime * 100);
    }


    protected void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoxCollider>() != null)
        {
            if (rb2d != null)
            {
                rb2d.isKinematic = false;
                Debug.Log("Dynamic again");
            }
        }
    }
}
