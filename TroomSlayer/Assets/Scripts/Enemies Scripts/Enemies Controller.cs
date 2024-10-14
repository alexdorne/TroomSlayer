using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class EnemiesController : MonoBehaviour
{
    // REFERENCES 

    CharacterMovement characterMovement;

    public Transform Target;

    // FLOATS 

    public float minDist = 0.2f;

    // INTS 


    // BOOLEANS 


    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }


    //First Time
    private void Update()
    {
        Vector3 difference = Target.position - transform.position;
        if (difference.magnitude > minDist)
            characterMovement.Movement(difference.x, difference.z);
    }


}
