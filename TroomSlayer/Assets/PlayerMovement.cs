using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // REFERENCES 

    Rigidbody rb;




    // FLOATS 

    private float MoveSpeed { get; set; }

    private float horizontalInput;
    private float verticalInput; 

    // INTS 


    // BOOLEANS 


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GatherInput();

        Movement(); 
    }

    private void GatherInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical"); 
    }

    private void Movement()
    {
        Vector3 movement = new Vector3(MoveSpeed * horizontalInput * Time.deltaTime, 0, MoveSpeed * verticalInput * Time.deltaTime); 
        //rb.angularVelocity = Vector3.Lerp()
    }

}
