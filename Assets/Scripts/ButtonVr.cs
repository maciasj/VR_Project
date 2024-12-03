using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ButtonVr : MonoBehaviour
{
    private Material buttonMaterial;
    private Color originalColor;             // Color original del bot�n
    public GameObject button;
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    bool muestraInfo;
    public float activationDistance = 1f;    // Distancia m�nima para activar el bot�n
    public XRNode controllerNode = XRNode.RightHand; // Nodo para el controlador (Right o Left Hand)
    public string interactionButton = "Trigger"; // Nombre del bot�n de interacci�n en el controlador
    public Transform raycastOrigin;
    public Canvas infoCanvas;                // Canvas que contiene el texto
    public TextMeshProUGUI infoText;         // Componente TextMeshProUGUI para mostrar el texto
    private Gamepad gamepad;

    void Start()
    {
        sound = GetComponent<AudioSource>(); 
        isPressed = false;
        infoCanvas.gameObject.SetActive(false);
        muestraInfo = false;
        gamepad = Gamepad.current;
        // Obtiene el material y guarda el color original
        Renderer renderer = button.GetComponent<Renderer>();
        if (renderer != null)
        {
            buttonMaterial = renderer.material;
            originalColor = buttonMaterial.color;
        }
        else
        {
            Debug.LogError("No se encontr� el componente Renderer en el objeto del bot�n.");
        }
    }

    void Update()
    {

       
        if (IsLookingAtButton() && gamepad.rightTrigger.wasPressedThisFrame && !isPressed)
        {
            muestraInfo = !muestraInfo; // Cambia el estado de muestraInfo
            PressButton();
        }
        else if (isPressed)
        {
            ReleaseButton();
        }
    }

    bool IsLookingAtButton()
    {
        Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ButtonVr button = hit.collider.GetComponent<ButtonVr>();

            if (button != null)
            {
                // Verifica si la distancia al bot�n es menor que la distancia de activaci�n
                if (Vector3.Distance(raycastOrigin.position, hit.point) < activationDistance)
                {
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    void PressButton()
    {
        // Cambia el color del bot�n: rojo si est� en el color original, o al color original si est� rojo
        if (buttonMaterial != null)
        {
            if (buttonMaterial.color == originalColor)
            {
                buttonMaterial.color = Color.red; // Cambia a rojo
            }
            else
            {
                buttonMaterial.color = originalColor; // Vuelve al color original
            }
        }

        sound.Play();
        isPressed = true;

        if (muestraInfo)
        {
            infoCanvas.gameObject.SetActive(true);
        }
        else
        {
            infoCanvas.gameObject.SetActive(false);
        }

        OnPress.Invoke();
    }

    void ReleaseButton()
    {
        isPressed = false;
        OnRelease.Invoke();
    }

    public void ShowInfoCuadro()
    {
        Debug.Log("Boton presionado");
    }
}
