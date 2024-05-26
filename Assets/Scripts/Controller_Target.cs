using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Target : MonoBehaviour
{
    public int targetNumber;

    public bool playerOnTarget;

    private void Start()
    {
        playerOnTarget = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Controller_Player player = other.GetComponent<Controller_Player>();
            if (player != null && player.playerNumber == targetNumber) ;
            {
                playerOnTarget = true;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<Controller_Player>().playerNumber == targetNumber)
            {
                playerOnTarget = false;
                //Debug.Log("P off T");
            }
        }
    }
}
