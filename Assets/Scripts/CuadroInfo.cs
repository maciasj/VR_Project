using UnityEngine;
using TMPro;
using System.Collections;

public class CuadroInfo : MonoBehaviour
{
    public Canvas infoCanvas;                // Canvas que contiene el texto
    public TextMeshProUGUI infoText;         // Componente TextMeshProUGUI para mostrar el texto
    public float tiempoEspera = 5f;        // Tiempo en segundos para retrasar la desaparici�n del texto
    private Coroutine ocultarCanvasCoroutine; // Corutina para gestionar el retraso en desactivar el Canvas

    void Start()
    {
        // Asegura que el Canvas est� desactivado al iniciar
        if (infoCanvas != null)
        {
            infoCanvas.gameObject.SetActive(false);
        }
    }

    public void Mirando(bool mirando)
    {
        if (infoCanvas != null && infoText != null)
        {
            // Si el jugador est� mirando, mostrar inmediatamente el Canvas y detener la corutina si est� corriendo
            if (mirando)
            {
                if (ocultarCanvasCoroutine != null)
                {
                    StopCoroutine(ocultarCanvasCoroutine);
                    ocultarCanvasCoroutine = null;
                }
                infoCanvas.gameObject.SetActive(true);
            }
            else
            {
                // Si el jugador deja de mirar, inicia la corutina para desactivar el Canvas despu�s del tiempo de espera
                if (ocultarCanvasCoroutine == null)
                {
                    ocultarCanvasCoroutine = StartCoroutine(OcultarCanvasConRetraso());
                }
            }
        }
    }

    private IEnumerator OcultarCanvasConRetraso()
    {
        // Espera el tiempo especificado antes de desactivar el Canvas
        yield return new WaitForSeconds(tiempoEspera);
        infoCanvas.gameObject.SetActive(false);
        ocultarCanvasCoroutine = null; // Resetea la corutina
    }
}
