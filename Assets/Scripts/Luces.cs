using UnityEngine;

public class HighlightOnProximity : MonoBehaviour
{
    public GameObject player; // Referencia al jugador o la c�mara VR
    public Light[] lights; // Array de focos en las esquinas del cuadro
    public float proximityDistance = 3.0f; // Distancia para activar las luces

    void Start()
    {
        // Aseg�rate de que las luces est�n apagadas al iniciar
        SetLightsState(false);
    }

    void Update()
    {
        // Calcula la distancia entre el jugador y el cuadro
        float distance = Vector3.Distance(player.transform.position, transform.position);
        // Si el jugador est� dentro de la distancia de proximidad, enciende las luces
        if (distance < proximityDistance)
        {
            SetLightsState(true);
        }
        else
        {
            SetLightsState(false);
        }
    }

    // M�todo para encender o apagar las luces
    void SetLightsState(bool state)
    {
        foreach (Light light in lights)
        {
            light.enabled = state;
        }
    }
}
