using UnityEngine;

public class RaycastMirada : MonoBehaviour
{
    private CuadroInfo lastCuadro; // Variable para almacenar el �ltimo cuadro detectado

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Inicializa lastCuadro en null al inicio de cada frame
        CuadroInfo currentCuadro = null;

        if (Physics.Raycast(ray, out hit))
        {
            // Verifica si el objeto tiene el script CuadroInfo
            currentCuadro = hit.collider.GetComponent<CuadroInfo>();
            if (currentCuadro != null)
            {
                currentCuadro.Mirando(true);
                
            }
        }

        // Si currentCuadro es null, significa que no est� mirando ning�n cuadro
        if (lastCuadro != null && currentCuadro != lastCuadro)
        {
            lastCuadro.Mirando(false); // Dejar de mirar el �ltimo cuadro detectado
            
        }

        // Actualiza lastCuadro al final del frame
        lastCuadro = currentCuadro;
    }
}

