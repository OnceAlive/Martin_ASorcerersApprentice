using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    //private GameInput gameInput;
    [SerializeField] private Transform playerTransform;
    private Vector3 mousePosition;
    
    private void Awake()
    {
        //gameInput = GameObject.FindGameObjectWithTag(Tags.T_GameInput).GetComponent<GameInput>();
    }
    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
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
