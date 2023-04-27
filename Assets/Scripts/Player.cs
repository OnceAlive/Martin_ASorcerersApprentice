using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private float movementSpeed;
    
    // Update is called once per frame
    private void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        Vector3 movementVector = gameInput.GetMovementVectorNormalized();
        
        
        
        transform.Translate(movementVector * (Time.deltaTime * movementSpeed));
    }
}
