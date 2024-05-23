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
                if (i >= 8) // Salida anticipada si se cumplen 8 objetivos
                {
                    winCondition = true;
                    break; // Opcional: usa break si necesitas más lógica después del bucle
                }
            }
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            actualPlayer = (actualPlayer - 1 + players.Count) % players.Count; // Lógica de cambio de jugador mejorada
            SetConstraits();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            actualPlayer = (actualPlayer + 1) % players.Count; // Lógica de cambio de jugador mejorada
        }
    }

    private void SetConstraits()
    {
        foreach (Controller_Player p in players)
        {
            if (p == players[actualPlayer])
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}