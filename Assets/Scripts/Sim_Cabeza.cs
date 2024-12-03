using UnityEngine;

public class SimuladorCabeza : MonoBehaviour
{
    public float sensibilidadMovimiento = 2.0f;

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    void Update()
    {
        // Obtiene la entrada del ratón
        rotacionX += Input.GetAxis("Mouse X") * sensibilidadMovimiento;
        rotacionY -= Input.GetAxis("Mouse Y") * sensibilidadMovimiento;
        rotacionY = Mathf.Clamp(rotacionY, -90f, 90f); // Limita la rotación vertical

        // Aplica la rotación a la cámara
        transform.localRotation = Quaternion.Euler(rotacionY, rotacionX, 0f);
    }
}
