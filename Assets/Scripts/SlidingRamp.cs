using UnityEngine;

public class SlidingRamp : MonoBehaviour
{
    public float slideTime = 2f; // Tiempo en segundos antes de que la rampa se deslice
    public float slideSpeed = 2f; // Velocidad de deslizamiento
    public float slideDistance = 1f; // Distancia a la que la rampa se deslizar�

    private float timer = 0f;
    private bool isSliding = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Verificar si el jugador est� quieto
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            timer += Time.deltaTime;

            // Comenzar a deslizar si el tiempo de espera se ha cumplido y la rampa a�n no est� desliz�ndose
            if (timer >= slideTime && !isSliding)
            {
                isSliding = true;
            }
        }
        else
        {
            // Reiniciar el temporizador si el jugador se mueve
            timer = 0f;
        }

        // Deslizar la rampa hacia abajo si est� activada
        if (isSliding)
        {
            Vector3 targetPosition = initialPosition - Vector3.up * slideDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, slideSpeed * Time.deltaTime);

            // Verificar si la rampa ha alcanzado su posici�n deslizada
            if (transform.position == targetPosition)
            {
                isSliding = false; // Detener el deslizamiento
            }
        }
        else
        {
            // Volver a la posici�n inicial si no se est� deslizando
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, slideSpeed * Time.deltaTime);
        }
    }
}