using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public InputAction mouseInput;
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private GameObject player;

    [SerializeField] private float xRotationMinClamp = 0.0f;
    [SerializeField] private float xRotationMaxClamp = 85.0f;

    private void Start() {
        mouseInput = new InputAction("mouseInput", binding: "<Mouse>/delta");
        mouseInput.Enable();
        mouseInput.performed += OnCameraRotate;
        transform.localEulerAngles.Set(0, 0, 0);
    }
    public void OnCameraRotate(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        player.transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
        float xRotation = transform.rotation.eulerAngles.x + -mouseDelta.y * mouseSensitivity;
        if(xRotation < 0)
        {
            xRotation += 360;
        }
        if(xRotation > xRotationMaxClamp && xRotation < 180f)
        {
            Debug.Log(xRotation);
            xRotation = xRotationMaxClamp;
        }
        else if(xRotation < xRotationMinClamp + 360 && xRotation > 180f)
        {
            Debug.Log(xRotation);
            xRotation = xRotationMinClamp;
        }
        Debug.Log(xRotation);
        transform.rotation = Quaternion.Euler(xRotation, transform.rotation.eulerAngles.y, transform.eulerAngles.z);
    }
}
