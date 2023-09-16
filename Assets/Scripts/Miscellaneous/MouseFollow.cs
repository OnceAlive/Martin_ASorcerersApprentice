using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private BoxCollider2D playerCollider;
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
            playerCollider.offset = new Vector2(-0.05061573f, 0.1555966f);
        }
        else
        {
            playerTransform.localScale = new Vector3(-1, 1, 1);
            playerCollider.offset = new Vector2(0.05061573f, 0.1555966f);
        }

        transform.right = -direction;
    }
}
