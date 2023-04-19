using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private GameInput gameInput;                               //reference to GameInput Object with its GameInput script

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVector2Normalized();
        Vector3 move = new Vector3(inputVector.x, inputVector.y, 0f);           //convert to Vector3 because GameObject.transform can't handle with Vector2
        
        float moveDistance = movementSpeed * Time.deltaTime;
        Vector3 halfExtents = transform.lossyScale / 2;                         //distance from center of a box to the faces on each axis

                                                                                //checks if there is any object
        bool canMove = !Physics.BoxCast(transform.position, halfExtents, move, new Quaternion(0,0,1,0), moveDistance);
        Debug.Log("Can Move? : " + canMove);

                                                                                //if there is an object player should not move
        if(!canMove)
        {
                                                                                //try to move just along the x-axis
            Vector2 moveX = new Vector2(move.x, 0f);
            canMove = !Physics.BoxCast(transform.position, halfExtents, moveX);

                                                                                //if there is no obstacle the movement direction is just along the x-axis
            if(canMove)
            {
                move = moveX;
            }
            else
            {
                                                                                //try to move along the y-axis
                Vector2 moveY = new Vector2(0f, move.y);
                canMove = !Physics.BoxCast(transform.position, halfExtents, moveY);

                                                                                //if there is no obstacle the movement direction is along the y-axis
                if(canMove)
                {
                    move = moveY;
                }
            }
        }

        
        if(canMove)
        {
            transform.position += move * moveDistance;                          //real movement of the player
        }
    }
}
