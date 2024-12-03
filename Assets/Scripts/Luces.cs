using UnityEngine;

public class HighlightOnProximity : MonoBehaviour
{
    public GameObject player; // Referencia al jugador o la cámara VR
    public Light[] lights; // Array de focos en las esquinas del cuadro
    public float proximityDistance = 3.0f; // Distancia para activar las luces

    void Start()
    {
        // Asegúrate de que las luces estén apagadas al iniciar
        SetLightsState(false);
    }

    void Update()
    {
        // Calcula la distancia entre el jugador y el cuadro
        float distance = Vector3.Distance(player.transform.position, transform.position);
        // Si el jugador está dentro de la distancia de proximidad, enciende las luces
        if (distance < proximityDistance)
        {
            SetLightsState(true);
        }
        else
        {
            SetLightsState(false);
        }
    }

    // Método para encender o apagar las luces
    void SetLightsState(bool state)
    {
        foreach (Light light in lights)
        {
            light.enabled = state;
        }
    }
}
