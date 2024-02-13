using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpPower = 5.0f;
    [SerializeField] private Vector2 moveVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        transform.Translate(moveVelocity * speed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVelocity = context.ReadValue<Vector2>();
    }

}
