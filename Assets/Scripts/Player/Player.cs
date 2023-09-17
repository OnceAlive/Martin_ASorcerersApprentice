using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //[SerializeField] private GameInput gameInput;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private float dashTime = .2f;
    [SerializeField] private float dashCooldown = 1.5f;
    [SerializeField] private SpriteRenderer martinRenderer;
    private Vector2 movementInput = Vector2.zero;
    private PlayerInput playerInput;
    public event EventHandler<float> OnDashStarted;
    
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    private Knockback knockback;
    private bool canDash = true;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Awake()
    {
        Time.timeScale = 1;
        knockback = GetComponent<Knockback>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandlePlayerMovement();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    public void OnDash(InputAction.CallbackContext context)
    {
        Dash();
    }
    
    private void HandlePlayerMovement()
    {
        if(knockback.gettingKnockedBack)
        {
            return;
        }

        /*
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movementInput.y), Mathf.Abs(movementInput.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, movementInput.y * (Time.deltaTime * movementSpeed), 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movementInput.x, 0), Mathf.Abs(movementInput.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(movementInput.x * (Time.deltaTime * movementSpeed), 0, 0);
        }*/

        transform.Translate(movementInput * (Time.deltaTime * movementSpeed));
    }

    private void Dash()
    {
        if (!canDash)
        {
            return;
        }

        canDash = false;
        movementSpeed *= dashSpeed;
        StartCoroutine(EndDashRoutine());
    }

    private IEnumerator EndDashRoutine()
    {
        EventHandler<float> eventHandler = OnDashStarted;
        eventHandler?.Invoke(this, dashCooldown + dashTime);
        GetComponent<BoxCollider2D>().enabled = false;
        martinRenderer.color = new Color(martinRenderer.color.r, martinRenderer.color.g, martinRenderer.color.b, .5f);
        yield return new WaitForSeconds(dashTime);
        movementSpeed /= dashSpeed;
        martinRenderer.color = new Color(martinRenderer.color.r, martinRenderer.color.g, martinRenderer.color.b, 1f);
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
