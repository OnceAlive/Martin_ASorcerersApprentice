using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    // Update is called once per frame
    private void Update()
    {

        //if ESC is pressed the application will close
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //returns direction of Player Movement
    public Vector2 GetMovementVector2Normalized()
    {
        Vector2 inputVector = playerInput.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;                                   //normalize for smooth movement

        return inputVector;
    }
}
