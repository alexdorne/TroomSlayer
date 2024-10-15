using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class DetectEnemies : MonoBehaviour
{
    public List<Transform> enemies = new List<Transform>();

    private void Update()
    {
        
    }

    public void SortList()
    {
        if (enemies.Count > 0)
        {
            enemies.Sort((x, y) => (int)Mathf.Sign((transform.position - x.position).magnitude - (transform.position - y.position).magnitude));
            //enemies.OrderBy((x) => (transform.position - x.position).magnitude);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Remove(other.transform);
        }
    }
}
