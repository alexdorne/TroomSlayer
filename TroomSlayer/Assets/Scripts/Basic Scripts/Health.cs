using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;

    public void DealDamage(AttackInfo attackInfo)
    {
        health -= attackInfo.damage;
    }
}
