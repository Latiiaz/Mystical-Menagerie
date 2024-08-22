using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSystem : MonoBehaviour //Script to handle Spirit Clicking/UI/Movement
{
    public float LerpSpeed = 5f;

    protected float targetXPos = 0f;
    protected float targetYPos = 0f;

    private GameObject _spiritLerp;

    void Start()
    {
        _spiritLerp = GameObject.Find("SpiritLerpLocation");
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        SpiritMovement();
    }
    
    void SpiritMovement()
    {
        if (_spiritLerp == null)
        {
            return;
        }

        float yPos = _spiritLerp.transform.position.y;
        float xPos = _spiritLerp.transform.position.x;
        targetXPos = Mathf.Lerp(targetXPos, _spiritLerp.transform.position.x, Time.deltaTime * LerpSpeed);
        targetYPos = Mathf.Lerp(targetYPos, _spiritLerp.transform.position.y, Time.deltaTime * 3 * LerpSpeed);
        transform.position = new Vector3(targetXPos, targetYPos, 0);
    }

    void LocationLerp()
    {

    }

    IEnumerator MovementCooldown()
    {
            yield return new WaitForSeconds(0.5f);
        
    }
}
