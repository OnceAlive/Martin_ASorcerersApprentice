using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private GameInput gameInput;
    [SerializeField] private Transform playerTransform;
    
    private void Awake()
    {
        gameInput = GameObject.FindGameObjectWithTag(Tags.T_GameInput).GetComponent<GameInput>();
    }
    
    private void Update()
    {
        FaceMouse();
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = gameInput.GetMousePosition();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = transform.position - mousePosition;
        if(direction.x < 0)
        {
            playerTransform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playerTransform.localScale = new Vector3(-1, 1, 1);
        }

        transform.right = -direction;
    }
}
