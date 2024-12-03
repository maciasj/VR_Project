using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class CardboardSliderAdjuster : MonoBehaviour
{
    public GameObject targetObject; // Asigna el modelo que deseas escalar
    public Camera mainCamera; // La camara que dispara el Raycast 
    public Slider currentSlider; // El slider con el que interactuar
    private bool isInteracting = false; // Si se esta en modo de interaccion
    private Gamepad gamepad;
    
    void Start()
    {
        gamepad = Gamepad.current;
    }

    void Update()
    {
        // Crear el Ray desde la posicion y direccion de la camara
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Detectar si el Raycast esta impactando en un objeto con Slider
        if (Physics.Raycast(ray, out hit))
        {
            

            if (hit.transform.CompareTag("Slider")){
                // Si el usuario presiona el boton Fire, se inicia la interaccion
                Debug.Log("Rayo lanzado al SLider");  
                if (gamepad.rightTrigger.isPressed)
                {
                    Debug.Log("Hola Estoy pulsando");
                    isInteracting = true;
                }

                // Si ya estamos en interaccion, actualizamos el valor del slider
                if (isInteracting )
                {
                    Debug.Log("Actualizando slider");  
                    // Calcular el valor del slider en funcion de la posicion en el slider
                    // Convertir la posicion del hit point en coordenadas locales del Slider
                    Vector3 localHitPoint = currentSlider.transform.InverseTransformPoint(hit.point);

                    // Normalizar el valor para ajustarlo a los valores del slider
                    float sliderValue = Mathf.InverseLerp(-currentSlider.GetComponent<RectTransform>().rect.width / 2, 
                                                          currentSlider.GetComponent<RectTransform>().rect.width / 2, 
                                                          localHitPoint.x);

                    // Ajustar el valor del slider
                    currentSlider.value = Mathf.Lerp(currentSlider.minValue, currentSlider.maxValue, sliderValue);
                    AdjustScale();
                    }
                
                if (!gamepad.rightTrigger.isPressed)
                {
                    Debug.Log("Adios");
                    isInteracting = false;
                 }
            }
        }
    }

        // Finalizar la interaccion cuando se suelta el boton Fire
       

        public void AdjustScale()
        {
            // Ajusta la escala del objeto en base al valor del Slider
            targetObject.transform.localScale = Vector3.one * currentSlider.value;
        }
}
