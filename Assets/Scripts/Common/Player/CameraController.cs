using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public InputAction mouseInput;
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private GameObject player;
    Vector3 rotation = Vector3.zero;

    private void Start() {
        mouseInput = new InputAction("mouseInput", binding: "<Mouse>/delta");
        mouseInput.Enable();
        mouseInput.performed += OnCameraRotate;
    }
    public void OnCameraRotate(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        player.transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
        transform.Rotate(Vector3.left * mouseDelta.y * mouseSensitivity);
    }
}
