using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RotateModel : MonoBehaviour
{
    public Transform modelTransform; // Asigna el transform del modelo que quieres rotar
    public Vector3 rotationChange = new Vector3(0, 5, 0); // Rotacion que se aplicara cada vez que pulses el boton

    // Método que sera llamado al pulsar el boton
    public void Rotate()
    {
        modelTransform.Rotate(rotationChange);
    }
}
