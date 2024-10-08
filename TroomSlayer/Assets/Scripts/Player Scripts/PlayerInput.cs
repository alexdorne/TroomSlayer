using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerInput : MonoBehaviour
{
    // REFERENCES 

    CharacterMovement characterMovement;

    Weapon equippedWeapon;

    [SerializeField] private List<Weapon> weapons = new List<Weapon>();

    // FLOATS 

    private float horizontalInput;
    private float verticalInput;

    private float attackDamage;
    private float attackSpeed; 

    // INTS 


    // BOOLEANS 

    private void Start()
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
        characterMovement.Movement(horizontalInput, verticalInput);
    }

    private void GatherInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical"); 



    }


}
