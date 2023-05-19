using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private float movementSpeed;
    private Vector3 direction;
    private GameObject projectileCopy;
    private float lifeTime = 1000;

    // Update is called once per frame
    private void Update()
    {
        HandlePlayerMovement();
        /*
        if (gameInput.ShootButtonPressed() && projectileCopy == null)
        {
            direction = Camera.main.ScreenPointToRay(Input.mousePosition).origin - transform.position;
            projectileCopy = Instantiate(projectile, caster.transform.position, new Quaternion(0, 0, 0, 0));
            lifeTime = 1000;
        }

        if (projectileCopy != null)
        {
            projectileCopy.transform.Translate(direction * Time.deltaTime);
            lifeTime--;
        }

        if (lifeTime <= 0)
        {
            Destroy(projectileCopy);
        }*/
    }

    private void HandlePlayerMovement()
    {
        Vector3 movementVector = gameInput.GetMovementVectorNormalized();
        
        
        
        transform.Translate(movementVector * (Time.deltaTime * movementSpeed));
    }
}
