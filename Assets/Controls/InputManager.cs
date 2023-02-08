using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    InputSystem input;
    [SerializeField] PlayerControl player;

    private void Awake()
    {
        input = new InputSystem();
    }

    private void OnEnable()
    {
        
        input.Player.Move.performed += DoMove;
        input.Player.Move.canceled += StopMove;
        input.Player.Jump.performed += DoJump;
        input.Enable();
    }

    private void DoJump(InputAction.CallbackContext ctx)
    {
        player.Jump();
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        player.Stop();
    }

    private void DoMove(InputAction.CallbackContext ctx)
    {
        player.Move(ctx.ReadValue<Vector2>());
        Debug.Log("Move performed in direction " + ctx.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
