using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowInfoOnClickVR : MonoBehaviour
{
    public Canvas infoCanvas;  // Canvas que contiene el texto
    public TextMeshProUGUI infoText;  // Referencia al TextMeshPro dentro del Canvas
    public Button actionButton;  // Botón para activar el Canvas
    public Transform raycastOrigin;  // El origen del raycast (generalmente el controlador VR)

    private void Start()
    {
        // Asegúrate de que el Canvas esté desactivado al inicio
        infoCanvas.gameObject.SetActive(false);

        // Vincula la función ShowInfo al botón
        actionButton.onClick.AddListener(ShowInfo);
    }

    private void Update()
    {
        // Lanza un raycast desde el controlador hacia el frente
        Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);
        RaycastHit hit;

        // Detecta si el raycast golpea un objeto con el componente Button
        if (Physics.Raycast(ray, out hit))
        {
            Button button = hit.collider.GetComponent<Button>();
            
            // Si se detecta el botón, verifica si se hace clic (ej. presionando un botón del controlador VR)
            if (button != null && Input.GetMouseButtonDown(1)) // Puedes ajustar el "Fire1" para el input de VR
            {
                Debug.Log("He entrado HE entrado HEHHEHE");
                button.onClick.Invoke();  // Llama al evento onClick del botón
            }
        }
       
    }

    // Método para mostrar la información
    void ShowInfo()
    {
        // Activa el Canvas
        infoCanvas.gameObject.SetActive(true);
    }
}
