using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private GameInput gameInput;

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVector2Normalized();
        Vector3 move = new Vector3(inputVector.x, inputVector.y, 0f);       //convert to Vector3 because GameObject.transform cant handle with Vector2

        float moveDistance = movementSpeed * Time.deltaTime;

        //checks if there is any object
        bool canMove = !Physics.Raycast(transform.position, move, moveDistance);
        Debug.Log(canMove);

        //if there is an object player should not move
        if(!canMove)
        {
            Vector2 moveX = new Vector2(move.x, 0f);
            canMove = !Physics.Raycast(transform.position, moveX, moveDistance);

            if(canMove)
            {
                move = moveX;
            }
            else
            {
                Vector2 moveY = new Vector2(0f, move.y);
                canMove = !Physics.Raycast(transform.position, moveY, moveDistance);

                if(canMove)
                {
                    move = moveY;
                }
            }
        }

        if(canMove)
        {
            transform.position += move * moveDistance;
        }
    }
}
