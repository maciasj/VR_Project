using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class moverGato : MonoBehaviour
   {
    private bool objetoSeleccionado = false;
    private Vector3 offset; // Desplazamiento entre el objeto y la posición de la cámara
    private Camera cam;
    public GameObject gato;
    private Gamepad gamepad;
    void Start()
    {
        cam = Camera.main; // Asignar la cámara principal
        gamepad = Gamepad.current;
    }

    void Update()
    {
        // Detectar si el objeto con el tag "gato" está seleccionado y se está manteniendo presionado
        if (gamepad.rightTrigger.isPressed)
        {
            Debug.Log("GAto Seleccionado");
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Gato"))
            {
                objetoSeleccionado = true;
            }
        }

        if (gamepad.rightTrigger.isPressed && objetoSeleccionado )
        {
            // Calcular la posición en la que se debe colocar el objeto
             Debug.Log("Pegar GAtp");
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("CilindroGato"))
            {   
                Vector3 newPosition = gato.transform.position ;
                newPosition.x = hit.transform.position.x;
                newPosition.z = hit.transform.position.z;
                gato.transform.position =  newPosition;
            }
        }

        // Soltar el objeto al soltar el botón del ratón
        
    }
}