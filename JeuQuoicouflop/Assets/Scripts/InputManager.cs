using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFloorActions onFloor;
    private PlayerMovement movement;
    private PlayerLook look;

    void Awake()
    {
        
        playerInput = new PlayerInput();
        onFloor = playerInput.OnFloor;

        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();

        onFloor.Jump.performed += ctx => movement.Jump();
        onFloor.Crouch.performed += ctx => movement.Crouch();
        onFloor.Sprint.performed += ctx => movement.Sprint();

    }

    private void FixedUpdate() {

        movement.ProcessMove(onFloor.Movement.ReadValue<Vector2>());
        
    }

    private void LateUpdate() {
        
        look.ProcessLook(onFloor.Look.ReadValue<Vector2>());

    }

    private void OnEnable() {
        
        onFloor.Enable();

    }

    private void onDisable() {
        
        onFloor.Disable();

    }
}
