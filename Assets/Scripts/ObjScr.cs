using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjData))]
public class ObjScr : MonoBehaviour, IObj
{
    private ObjData data;

    private void Start()
    {
        data = GetComponent<ObjData>();
    }
    public void ApplyDamage(int damage)
    {
        data.health -= damage;

        if (data.health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
