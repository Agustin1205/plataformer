using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Transform pointA; // Punto de origen
    public Transform pointB; // Punto de destino
    public float speed = 1.0f; // Velocidad de movimiento

    private Vector3 targetPosition; // Posición objetivo

    void Start()
    {
        // Inicializar la posición objetivo al punto A
        targetPosition = pointA.position;
    }

    void Update()
    {
        // Mover el objeto hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Verificar si el objeto ha alcanzado la posición objetivo
        if (transform.position == targetPosition)
        {
            // Cambiar la posición objetivo al punto B si estaba en A, y viceversa
            if (targetPosition == pointA.position)
            {
                targetPosition = pointB.position;
            }
            else
            {
                targetPosition = pointA.position;
            }
        }
    }
}