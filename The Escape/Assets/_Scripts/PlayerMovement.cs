using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float mouseSensitivity = 2f;
    public Transform playerCamera;
    private CharacterController controller;
    private float verticalRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Skip movement & mouse look if UI is active
        if (UIManager.isUIActive)
        {
            // Ensure cursor is visible and unlocked
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }

        // Cursor hidden & locked during gameplay
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.SimpleMove(move * speed);
    }
}
