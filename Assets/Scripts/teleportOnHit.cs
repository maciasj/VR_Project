using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class teleportOnHit : MonoBehaviour
{
    private bool isSelected = false;
    private Transform targetObject; // Objeto al que queremos teletransportar
    private Gamepad gamepad;

    void Start()
    {
        gamepad = Gamepad.current;
    }

    void Update()
    {
        // Obtener el rayo desde el Google Cardboard Reticle
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Realizar el raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Comprobar si el raycast golpea el objeto y si el botón de Cardboard está activado
            if (isSelected && gamepad.rightTrigger.wasPressedThisFrame)
            {
                // Teletransportar el objeto a la posición golpeada
                targetObject.position = hit.point;
                isSelected = false; // Desactivar la selección después del teletransporte
            }
            else if (hit.transform == transform && gamepad.rightTrigger.wasPressedThisFrame)
            {
                // Si el objeto fue seleccionado, marcarlo para el próximo teletransporte
                targetObject = hit.transform;
                isSelected = true;
            }
        }
    }
}
