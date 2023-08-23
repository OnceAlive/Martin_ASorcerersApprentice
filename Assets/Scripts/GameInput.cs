using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private static PlayerInput playerInput;

    public InputAction Dash;
    public InputAction Attack;
    public InputAction InventoryKeyboard;
    
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        
        Dash = playerInput.Player.dash;
        Attack = playerInput.Player.attack;
        InventoryKeyboard = playerInput.Player.inventory_keyboard;
    }
    
    public Vector3 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        
        return new Vector3(inputVector.x, inputVector.y, 0);
    }
    
    public Vector3 GetMousePosition()
    {
        Vector2 mousePosition = playerInput.Player.mouse_position.ReadValue<Vector2>();
        
        return new Vector3(mousePosition.x, mousePosition.y, 0);
    }
}
