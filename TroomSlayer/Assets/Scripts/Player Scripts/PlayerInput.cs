using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerInput : MonoBehaviour
{
    // REFERENCES 

    CharacterMovement characterMovement; 
    [SerializeField] DetectEnemies detectEnemies;

    // FLOATS 

    private float horizontalInput;
    private float verticalInput;

    private Transform lockedEnemyPos; 

    // INTS 


    // BOOLEANS 

    private bool lockedOnEnemy; 

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        //characterMovement.KnockBack(5, Vector3.forward, 0.25f);
    }


    private void Update()
    {
        GatherInput();

        LockOnEnemy();

    }

    private void FixedUpdate()
    {
        characterMovement.Movement(horizontalInput, verticalInput);
    }

    private void GatherInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 
    }

    private void LockOnEnemy()
    {
        float x;
        float z; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lockedOnEnemy = !lockedOnEnemy;

            if (lockedOnEnemy)
                detectEnemies.SortList();

            lockedEnemyPos = detectEnemies.enemies[0].transform; 
        }

        if (Input.GetKeyDown(KeyCode.Tab) && detectEnemies.enemies.Count > 1)
        {
            detectEnemies.SortList(); 
            lockedEnemyPos = detectEnemies.enemies[0].transform;
        }

        if (!lockedOnEnemy)
        {
            x = horizontalInput;
            z = verticalInput;
        }
        else
        {
            x = lockedEnemyPos.position.x - transform.position.x;
            z = lockedEnemyPos.position.z - transform.position.z; 
        }

        characterMovement.RotateToDirection(new Vector3(x, 0, z));

    }


}
