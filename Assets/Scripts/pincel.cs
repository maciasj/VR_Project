using UnityEngine;
using UnityEngine.InputSystem;

public class PaintOnCanvas : MonoBehaviour
{
    public Camera mainCamera;
    public RenderTexture renderTexture; // Asignar en el editor
    private Texture2D paintTexture;
    public Color paintColor = Color.red;
    public float brushSize = 10.0f;
    public GameObject colorRojo;
    public GameObject colorAamrillo;
    public GameObject colorAzul;
    public GameObject colorVerde;
    public GameObject colorBlanco;
    private Gamepad gamepad;

    void Start()
    {
        // Crear una nueva Texture2D con un formato compatible
        paintTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);

        // Asignar la textura al material del lienzo
        GetComponent<Renderer>().material.mainTexture = paintTexture;
        colorRojo.SetActive(false);
        colorAamrillo.SetActive(false);
        colorAzul.SetActive(false);
        colorVerde.SetActive(false);
        colorBlanco.SetActive(false);
        gamepad = Gamepad.current;
    }

    void Update()
    {
        Debug.Log("NoPintando");
        if (gamepad.rightTrigger.isPressed) // Aqu� usar�s la entrada del controlador VR
        {
           Debug.Log("Pulsando");
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Canvas")) // Aseg�rate de que el lienzo tenga la etiqueta "Canvas"
            {
                Debug.Log("Pintando en el canvas");
                Paint(hit.textureCoord);
            }
        }
        muestraColorSeleccionado();
        }

        }
    

    void Paint(Vector2 uv)
    {
        // Convertir las coordenadas UV a coordenadas de la textura
        int x = Mathf.RoundToInt(uv.x * paintTexture.width);
        int y = Mathf.RoundToInt(uv.y * paintTexture.height);

        // Pintar en la textura
        for (int i = -Mathf.RoundToInt(brushSize); i < Mathf.RoundToInt(brushSize); i++)
        {
            for (int j = -Mathf.RoundToInt(brushSize); j < Mathf.RoundToInt(brushSize); j++)
            {
                int px = x + i;
                int py = y + j;
                if (px >= 0 && px < paintTexture.width && py >= 0 && py < paintTexture.height)
                {
                    paintTexture.SetPixel(px, py, paintColor);
                }
            }
        }

        paintTexture.Apply(); // Aplica los cambios a la textura
    }


    void muestraColorSeleccionado(){
        colorRojo.SetActive(paintColor==Color.red);
        colorAamrillo.SetActive(paintColor==Color.yellow);
        colorAzul.SetActive(paintColor==Color.blue);
        colorVerde.SetActive(paintColor==Color.green);
        colorBlanco.SetActive(paintColor==Color.white);
    }
}
