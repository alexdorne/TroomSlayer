using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerInput : MonoBehaviour
{
    // REFERENCES 

    CharacterMovement characterMovement; 

    // FLOATS 

    private float horizontalInput;
    private float verticalInput;

    // INTS 


    // BOOLEANS 

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterMovement.KnockBack(5, Vector3.forward, 0.25f);
    }


    private void Update()
    {
        GatherInput();

    }

    private void FixedUpdate()
    {
        //Movement(horizontalInput, verticalInput);
        //RotateToDirection();
        characterMovement.Movement(horizontalInput, verticalInput);
    }

    private void GatherInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 
    }

    //private void Movement(float xDirection, float yDirection)
    //{
    //    Vector3 moveDirection = new Vector3(xDirection, 0, yDirection);
    //    moveDirection = Vector3.ClampMagnitude(moveDirection, 1f); 
    //    Vector3 movement = new Vector3(10 * moveSpeed * moveDirection.x * Time.deltaTime, rb.linearVelocity.y, 10 * moveSpeed * moveDirection.z * Time.deltaTime);
    //    rb.linearVelocity = Vector3.Lerp(transform.position, movement, acceleration); 
    //}

    //private void RotateToDirection()
    //{
    //    float singleStep = rotationSpeed * Time.deltaTime;
    //    Vector3 lookDirection = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);  
    //    Vector3 newRotation = Vector3.RotateTowards(transform.forward, lookDirection, singleStep, 0.0f);
    //    //transform.rotation = Quaternion.LookRotation(newRotation);
    //    rb.rotation = Quaternion.LookRotation(newRotation);
    //}

}
