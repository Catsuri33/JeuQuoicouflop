using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFloorActions onFloor;
    private PlayerMovement movement;

    void Awake()
    {
        
        playerInput = new PlayerInput();
        onFloor = playerInput.OnFloor;
        movement = GetComponent<PlayerMovement>();

    }

    private void FixedUpdate() {

        movement.ProcessMove(onFloor.Movement.ReadValue<Vector2>());
        
    }

    private void OnEnable() {
        
        onFloor.Enable();

    }

    private void onDisable() {
        
        onFloor.Disable();

    }
}
