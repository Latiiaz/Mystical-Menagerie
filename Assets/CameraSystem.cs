using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Vector2 PositionOffset = Vector2.zero;
    public float LerpSpeed = 5f;

    protected float targetXPos = 0f;
    protected float targetYPos = 0f;

    private GameObject player;

    private float xMin = -299f, xMax = 299f;
    private float yMin = -299f, yMax = 299f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        float yPos = player.transform.position.y;
        float xPos = player.transform.position.x;
        targetXPos = Mathf.Lerp(targetXPos, player.transform.position.x, Time.deltaTime * LerpSpeed);
        targetYPos = Mathf.Lerp(targetYPos, player.transform.position.y, Time.deltaTime * 3 * LerpSpeed);

        float clampxpos = Mathf.Clamp(targetXPos, xMin, xMax);
        float clampypos = Mathf.Clamp(targetYPos, yMin, yMax);

        transform.position = new Vector3(clampxpos, clampypos, -10f);
    }
}
