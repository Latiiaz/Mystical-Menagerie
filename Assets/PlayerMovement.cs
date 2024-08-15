using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {
        Movement();
    }

    void ProcessInputs()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movementX, movementY).normalized;
    }
    void Movement()
    {
       rb.velocity = new Vector2(moveDirection.x*moveSpeed, moveDirection.y*moveSpeed);
    }
}
