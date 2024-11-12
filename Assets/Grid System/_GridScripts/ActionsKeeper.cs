using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsKeeper : MonoBehaviour
{
    //Script to handle everything about the player's score

    private int _steps;

    static ActionsKeeper instance;

    private void Awake()
    {

        SingletonActionsKeeper();
    }

    void SingletonActionsKeeper()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public int GetActions()
    {
        return _steps;
    }

    public void ModifyScore(int value)
    {
        _steps += value;
        Mathf.Clamp(_steps, 0, int.MaxValue);
        Debug.Log(_steps);
    }

    public void ResetScore()
    {
        _steps = 0;
    }

}