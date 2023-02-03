using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MarioMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector3 moveInput;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed* Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector3>();
    }
}
