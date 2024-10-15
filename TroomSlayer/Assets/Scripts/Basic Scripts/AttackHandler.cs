using System;
using UnityEngine;

[Serializable]
public struct AttackInfo
{
    public int damage;
}


public class AttackHandler : MonoBehaviour
{
    // REFERENCES

    [SerializeField] Collider hitTrigger;

    // FLOATS


    // INTS


    // BOOLEANS

    public bool isPlayer;

    // STRUCTURES

    public AttackInfo info;

    private void Start()
    {

    }

    private void Update()
    {
        hitTrigger.enabled = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Hittable hittable))
        {
            if (isPlayer != hittable.isPlayer)
                hittable.Hit(info);
        }
    }


}
