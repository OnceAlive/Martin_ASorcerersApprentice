using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private float dashTime = .2f;
    
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    public static Player INSTANCE;

    private Knockback knockback;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        gameInput.Dash.performed += _ => Dash();
    }

    private void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }

        knockback = GetComponent<Knockback>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        if(knockback.gettingKnockedBack)
        {
            return;
        }
        
        Vector3 movementVector = gameInput.GetMovementVectorNormalized();

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movementVector.y), Mathf.Abs(movementVector.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, movementVector.y * (Time.deltaTime * movementSpeed), 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movementVector.x, 0), Mathf.Abs(movementVector.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(movementVector.x * (Time.deltaTime * movementSpeed), 0, 0);
        }

        //transform.Translate(movementVector * (Time.deltaTime * movementSpeed));
    }

    private void Dash()
    {
        movementSpeed *= dashSpeed;
        StartCoroutine(EndDashRoutine());
    }

    private IEnumerator EndDashRoutine()
    {
        yield return new WaitForSeconds(dashTime);
        movementSpeed /= dashSpeed;
    }
}
