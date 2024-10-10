using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Vector2 PositionOffset = Vector2.zero;
    public float LerpSpeed = 5f;

    protected float targetXPos = 0f;
    protected float targetYPos = 0f;

    [SerializeField] private GameObject _player;

    private float xMin = -299f, xMax = 299f;
    private float yMin = -299f, yMax = 299f;

    // Start is called before the first frame update
    void Start()
    {

        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player == null)
        {
            return;
        }

        targetXPos = _player.transform.position.y;
        targetYPos = _player.transform.position.x;
        float clampxpos = Mathf.Clamp(targetXPos, xMin, xMax);
        float clampypos = Mathf.Clamp(targetYPos, yMin, yMax);

        transform.position = new Vector3(clampxpos, clampypos, -10f);
    }
}
