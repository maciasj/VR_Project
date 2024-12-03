using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class ReticleTeleport : MonoBehaviour
{
    public Transform player;  // El objeto que se teletransportara
    private Vector3 newPosition;
    public Camera MainCamera;
    public Transform modelTransform;
    public Vector3 rotationChange = new Vector3(0, 5, 0);
    private bool rotate = false;
    public Slider currentSlider = null; // Slider que estA siendo controlado
    private bool isInteracting = false;
    private Gamepad gamepad;
    public Transform reticlePointer;

    void Start()
    {
        gamepad = Gamepad.current;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        // Usa la posición del puntero de la retícula en lugar del mouse
        Vector2 rayOrigin = reticlePointer.transform.position;

        // Realiza un Raycast2D desde el punto de origen del reticle
        RaycastHit2D hit2d = Physics2D.Raycast(rayOrigin, reticlePointer.transform.forward);


        // Lanzar un rayo desde el Reticle Pointer hacia adelante
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Rayo lanzado");  
            // Verificar si el rayo esta apuntando a un objeto con la etiqueta "TeleportTarget"
            if (hit.transform.CompareTag("TeleportTarget"))
            {
                Vector3 posicionTP = hit.collider.transform.position;
                // Verificar si se ha presionado el boton del mando
                if (gamepad.rightTrigger.wasPressedThisFrame)  // Cambia "Fire1" segun el mapeo de tu boton
                {
                    TeleportPlayer(posicionTP);
                }
            }
            if (hit.transform.CompareTag("RotateTarget")){
                Debug.Log("Apuntando RT");
                // Verificar si se ha presionado el boton del mando
                if (gamepad.rightTrigger.wasPressedThisFrame)  // Cambia "Fire1" segun el mapeo de tu boton
                {
                    Debug.Log("Fuego Fuego Fire Fire");
                    rotate = !rotate;
                    ///hit.transform.GetComponent<RotateModel>().Rotate();
                }
            }
            
        }
        if(rotate){
                modelTransform.Rotate(rotationChange);
            }

        
        if (hit2d.collider != null){
            currentSlider = hit2d.collider.GetComponent<Slider>();
            if(currentSlider != null){
                Debug.Log("FSlider0");
                // Si impactamos un Slider y se presiona el botOn de acciOn (por ejemplo, botOn derecho del mouse)
                if (gamepad.rightTrigger.wasPressedThisFrame) // Ajusta Input para tu controlador VR
                    {
                        Debug.Log("FSlider1");
                        isInteracting = true;
                    }
                if (isInteracting )
                        {
                        Vector2 localPoint;  // Cambiado a Vector2

                        // Obtén la posición de pantalla del reticle pointer
                        Vector2 screenPoint = MainCamera.WorldToScreenPoint(reticlePointer.position);

                        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                            currentSlider.GetComponent<RectTransform>(),
                            screenPoint,  // Usa la posición de pantalla calculada desde el reticle pointer
                            MainCamera,   // Asegúrate de que el nombre de la cámara sea correcto
                            out localPoint
                        );

                    // Convertir la posiciOn en un valor normalizado entre el mInimo y mAximo del slider
                    float sliderValue = Mathf.InverseLerp(
                                -currentSlider.GetComponent<RectTransform>().rect.width / 2,
                                currentSlider.GetComponent<RectTransform>().rect.width / 2,
                                localPoint.x
                            );

                            // Ajustar el valor del Slider
                            currentSlider.value = Mathf.Lerp(currentSlider.minValue, currentSlider.maxValue, sliderValue);
                        }

        // Salir del modo de interacciOn al soltar el botOn
        if (gamepad.leftTrigger.wasPressedThisFrame)
            {
                 Debug.Log("FSlider333");
                isInteracting = false;
                currentSlider = null;
            }
            }
        }
        }

    void TeleportPlayer(Vector3 posicionTP)
    {
        Debug.Log("Iniciando TP");
        // Ajustar la altura del teletransporte para que el jugador no quede en el suelo
        Vector3 posicionPlayer = posicionTP;
        posicionTP.y = 1.11f;
        player.position = posicionTP;
        MainCamera.transform.localPosition  = Vector3.zero;
        
    }

   
}
