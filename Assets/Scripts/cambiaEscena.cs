using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class cambiaEscena : MonoBehaviour
{
    private Gamepad gamepad;
    // Start is called before the first frame update
    void Start()
    {
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
     void Update()
    {
    
        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("TAG "+hit.transform.tag);
                // Comprueba el nombre o etiqueta de la puerta
                switch (hit.transform.tag)
                {
                    case "PuertaPintar":
                        SceneManager.LoadScene("Museo_3");
                        break;
                    case "PuertaCuadros":
                        SceneManager.LoadScene("Muse_Cuadros");
                        break;
                    case "PuertaEstatuas":
                        SceneManager.LoadScene("Museo_1");
                        break;
                    // Agrega más puertas según necesites
                    default:
                        Debug.Log("No hay escena asignada para esta puerta.");
                        break;
                }
            }
        }
    }
}

