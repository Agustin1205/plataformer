using UnityEngine;

public class Player7Controller : MonoBehaviour
{
    private bool isSlowMotionActive = false;
    private float slowMotionDuration = 5f;
    private float slowMotionTimer = 0f;

    void Update()
    {
        // Verificar si se ha presionado la tecla G y el slow motion no está activo
        if (Input.GetKeyDown(KeyCode.G) && !isSlowMotionActive)
        {
            // Activar el slow motion
            isSlowMotionActive = true;
            slowMotionTimer = 0f;
            Time.timeScale = 0.5f; // Reducir la escala de tiempo a la mitad (50% de la velocidad normal)
        }

        // Verificar si el slow motion está activo
        if (isSlowMotionActive)
        {
            // Incrementar el temporizador del slow motion
            slowMotionTimer += Time.deltaTime;

            // Verificar si ha pasado el tiempo de duración del slow motion
            if (slowMotionTimer >= slowMotionDuration)
            {
                // Desactivar el slow motion y restaurar la escala de tiempo normal
                isSlowMotionActive = false;
                Time.timeScale = 1f;
            }
        }
    }
}