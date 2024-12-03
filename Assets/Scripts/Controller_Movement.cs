using UnityEngine;
using UnityEngine.InputSystem;

public class Controller_movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    private GameObject currentLookAtObject;
    public float maxRaycastDistance = 50f;  // Maximum raycast distance
    public LayerMask interactableLayer; // Assign in the Inspector


    public Transform playerCamera;


 

    private Gamepad gamepad;
    private Mouse mouse;

    

  

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        gamepad = Gamepad.current;
        mouse = Mouse.current;

    }

    private void FixedUpdate()
    {
        if (gamepad != null)
        {
            // **Move Player** using the left stick input, adjusted for camera direction
            Vector2 moveInput = gamepad.leftStick.ReadValue();

            // Calculate the camera-based movement direction
            Vector3 forward = playerCamera.forward;
            Vector3 right = playerCamera.right;

            // Flatten the forward and right vectors so movement stays horizontal
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            // Calculate the desired move direction
            Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
            Vector3 move = moveDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }
}