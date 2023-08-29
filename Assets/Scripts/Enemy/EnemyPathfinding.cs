using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = .2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Knockback knockback;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<Knockback>();
    }

    private void FixedUpdate()
    {
        if(knockback.gettingKnockedBack)
        {
            return;
        }

        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDirection = targetPosition;
    }
}
