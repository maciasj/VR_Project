using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowInfoOnClickVR : MonoBehaviour
{
    public Canvas infoCanvas;  // Canvas que contiene el texto
    public TextMeshProUGUI infoText;  // Referencia al TextMeshPro dentro del Canvas
    public Button actionButton;  // Bot�n para activar el Canvas
    public Transform raycastOrigin;  // El origen del raycast (generalmente el controlador VR)

    private void Start()
    {
        // Aseg�rate de que el Canvas est� desactivado al inicio
        infoCanvas.gameObject.SetActive(false);

        // Vincula la funci�n ShowInfo al bot�n
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
            
            // Si se detecta el bot�n, verifica si se hace clic (ej. presionando un bot�n del controlador VR)
            if (button != null && Input.GetMouseButtonDown(1)) // Puedes ajustar el "Fire1" para el input de VR
            {
                Debug.Log("He entrado HE entrado HEHHEHE");
                button.onClick.Invoke();  // Llama al evento onClick del bot�n
            }
        }
       
    }

    // M�todo para mostrar la informaci�n
    void ShowInfo()
    {
        // Activa el Canvas
        infoCanvas.gameObject.SetActive(true);
    }
}
