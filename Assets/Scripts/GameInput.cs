using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool ShootButtonPressed()
    {
        return playerInput.Player.shoot.IsPressed();
    }
}
