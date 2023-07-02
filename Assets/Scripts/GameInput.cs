using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInput playerInput;
    
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }
    

    public Vector3 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        
        return new Vector3(inputVector.x, inputVector.y, 0);
    }
    
    public bool GetAttackButtonPressed()
    {
        return playerInput.Player.attack.triggered;
    }

    public Vector3 GetMousePosition()
    {
        Vector2 mousePosition = playerInput.Player.mouse_position.ReadValue<Vector2>();
        
        return new Vector3(mousePosition.x, mousePosition.y, 0);
    }
    
    public bool GetInventorySlotNumber()
    {
        //TODO: implement
        return false; //placeholder
    }
}
