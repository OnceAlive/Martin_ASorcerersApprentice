using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private float movementSpeed;

    public static Player INSTANCE;

    private Knockback knockback;

    private void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }

        knockback = GetComponent<Knockback>();
    }

    // Update is called once per frame
    private void Update()
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
        
        transform.Translate(movementVector * (Time.deltaTime * movementSpeed));
    }
}
