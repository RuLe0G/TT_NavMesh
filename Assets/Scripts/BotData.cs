using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotData : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int movSpeed;

    public void ApplyDamage(int damage)
    { 
        _health -= damage;

        if (_health < 0)
        { 
            Die();
        }
    }
    public void Die()
    { 
        Destroy(gameObject);
    }
}
