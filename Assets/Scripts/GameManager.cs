using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool winCondition = false;
    public static int actualPlayer = 0;

    public List<Controller_Target> targets;
    public List<Controller_Player> players;

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SetConstraits();
    }

    void Update()
    {
        GetInput();
        CheckWin();
    }

    private void CheckWin()
    {
        int i = 0;
        foreach (Controller_Target t in targets)
        {
            if (t.playerOnTarget)
            {
                i++;
            }
        }
        if (i >= 8)
        {
            winCondition = true;
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            actualPlayer = (actualPlayer <= 0) ? players.Count - 1 : actualPlayer - 1;
            SetConstraits();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            actualPlayer = (actualPlayer >= players.Count - 1) ? 0 : actualPlayer + 1;
            SetConstraits();
        }
    }

    private void SetConstraits()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (i == actualPlayer)
            {
                players[i].rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                players[i].rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}
