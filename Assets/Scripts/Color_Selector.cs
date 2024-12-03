using UnityEngine;
using UnityEngine.InputSystem;

public class ColorPicker : MonoBehaviour
{
    public PaintOnCanvas paintOnCanvas; // Asigna tu script de pintura en el editor
    public Camera mainCamera;
    private Gamepad gamepad;

    void Start()
    {
        gamepad = Gamepad.current;
    }   

    void Update()
    {
        // Detectar si se hace clic con el bot�n izquierdo del rat�n
        if (gamepad.rightTrigger.wasPressedThisFrame)
            {
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hit))
            {
            // Verificar si se ha hecho clic en uno de los cubos y cambiar el color
                if (hit.collider.CompareTag("red_paint"))
                {
                    paintOnCanvas.paintColor = Color.red;
                }
                else if (hit.collider.CompareTag("green_paint"))
                {
                    paintOnCanvas.paintColor = Color.green;
                }
                else if (hit.collider.CompareTag("blue_paint"))
                {
                    paintOnCanvas.paintColor = Color.blue;
                }
                else if (hit.collider.CompareTag("yellow_paint"))
                {
                    paintOnCanvas.paintColor = Color.yellow;
                }
               
                else if (hit.collider.CompareTag("white_paint"))
                {
                    paintOnCanvas.paintColor = Color.white;
                }
               
        }
        }
    }
}
