using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Hittable : MonoBehaviour
{
    // REFERENCES
    [SerializeField] Collider hitBox;
    [SerializeField] UnityEvent<AttackInfo> attackEvent;

    public bool isPlayer;

    private void Awake()
    {
        hitBox = GetComponent<Collider>();
    }

    public void Hit(AttackInfo info)
    {
        Debug.Log("hit");
        attackEvent?.Invoke(info);
    }
}
