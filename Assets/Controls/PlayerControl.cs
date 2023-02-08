using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;
    private Rigidbody rb;
    private Vector2 moveValue;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(moveValue.x, 0f, moveValue.y);
        moveDirection = mainCamera.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;
        rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    public void Move(Vector2 dir)
    {
        moveValue = dir;
    }
    public void Stop()
    {
        moveValue = Vector2.zero;
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
        Debug.Log("Jump");

    }
}
