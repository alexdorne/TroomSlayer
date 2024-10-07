using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    // REFERENCES 

    Rigidbody rb;

    // FLOATS 

    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float stunTime;

    private float xMovement; 
    private float zMovement;


    // INTS 


    // BOOLEANS 


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        RotateToDirection();
        stunTime -= Time.fixedDeltaTime; 
    }


    public void Movement(float xDirection, float yDirection)
    {
        if (stunTime <= 0)
        {
            xMovement = xDirection;
            zMovement = yDirection;
        }

        Vector3 moveDirection = new Vector3(xMovement, 0, zMovement);
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
        Vector3 movement = new Vector3(10 * moveSpeed * moveDirection.x * Time.deltaTime, rb.linearVelocity.y, 10 * moveSpeed * moveDirection.z * Time.deltaTime);
        rb.linearVelocity = Vector3.Lerp(transform.position, movement, acceleration);
    }

    private void RotateToDirection()
    {
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 lookDirection = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, lookDirection, singleStep, 0.0f);
        rb.rotation = Quaternion.LookRotation(newRotation);
    }

    public void Stun(float time)
    {
        if (time > stunTime)
        {
            stunTime = time;
            xMovement = 0; zMovement = 0;
        }
    }

    public void KnockBack (float distance, Vector3 direction, float time)
    {
        direction.Normalize();
        Stun(time);
        Vector3 movement = direction * distance / time;
        xMovement = movement.x;
        zMovement = movement.z;
        

    }
}
