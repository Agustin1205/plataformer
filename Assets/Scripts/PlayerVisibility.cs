using UnityEngine;

public class VisibilidadPlayer6 : MonoBehaviour
{
    private bool isVisible = true;

    void Update()
    {
        // Verificar si se ha presionado la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Cambiar la visibilidad del objeto
            isVisible = !isVisible;

            // Mostrar u ocultar el objeto según su estado
            if (isVisible)
            {
                GetComponent<Renderer>().enabled = true; // Mostrar el objeto
                GetComponent<Collider>().enabled = true; // Habilitar el collider si lo tiene
            }
            else
            {
                GetComponent<Renderer>().enabled = false; // Ocultar el objeto
                GetComponent<Collider>().enabled = false; // Deshabilitar el collider si lo tiene
            }
        }
    }
}