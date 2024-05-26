using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    // Referencia al GameObject del player1
    public GameObject player1;

    // Factor de escala para reducir el tama�o
    private float scaleFactor = 0.5f;

    // Variable para controlar si el jugador est� reducido
    private bool isPlayerReduced = false;

    void Update()
    {
        // Si se presiona la tecla C
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Invierte el estado de reducci�n del jugador
            isPlayerReduced = !isPlayerReduced;

            // Aplica la escala al player1
            if (isPlayerReduced)
            {
                player1.transform.localScale = player1.transform.localScale * scaleFactor;
            }
            else
            {
                player1.transform.localScale = player1.transform.localScale / scaleFactor;
            }
        }
    }
}