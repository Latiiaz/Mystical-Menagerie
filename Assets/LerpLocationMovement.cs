using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpLocationMovement : MonoBehaviour
{
    [SerializeField] float movementCooldown;

    public bool moveLocation = true;

    private bool movementUp = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovementCooldown());

    }

    // Update is called once per frame
    void Update()
    {
        if (movementUp == true)
        {

        }

    }

    IEnumerator MovementCooldown()
    {
        if (moveLocation == true)
        {
            yield return new WaitForSeconds(movementCooldown);
        }
    }

    void MoveLocation()
    {

    }
}
