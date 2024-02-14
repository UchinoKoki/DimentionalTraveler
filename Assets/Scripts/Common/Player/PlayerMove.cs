using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1f;                        //プレイヤーの移動速度
    [SerializeField] private Vector2 moveVelocity;  //プレイヤーの移動方向

    Rigidbody rb;                                   //プレイヤーのRigidbody
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        Move();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVelocity = context.ReadValue<Vector2>();
    }
    private void Move()
    {
        rb.velocity = transform.TransformDirection(-moveVelocity.x* speed,0f,-moveVelocity.y* speed);
    }

}
