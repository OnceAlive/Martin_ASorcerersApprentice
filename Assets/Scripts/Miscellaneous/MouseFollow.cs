using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 mousePosition;
    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        if (PauseMenu.IsPaused)
        {
            return;
        }
        
        mousePosition = context.ReadValue<Vector2>();
        FaceMouse();
    }

    private void FaceMouse()
    {
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
