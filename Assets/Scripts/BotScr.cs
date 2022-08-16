using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BotData), typeof(BotMovement))]
public class BotScr : MonoBehaviour, IBot
{
    private BotData data;
    private BotMovement movement;

    private void Start()
    {
        data = GetComponent<BotData>();
        movement = GetComponent<BotMovement>();
    }

    public void ApplyDamage(int damage)
    {
        data.health -= damage;

        if (data.health <= 0)
        {
            Die();
        }
    }

    public void Attach(ObjData targ)
    {
        movement.MoveToTarg();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void FindTarg()
    {
        throw new System.NotImplementedException();
    }

    public void Generate()
    {
    }

    public void IncreaseDamage(int mod)
    {
        data.damage += mod;
    }
}
