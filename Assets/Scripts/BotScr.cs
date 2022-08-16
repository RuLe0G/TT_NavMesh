using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BotData), typeof(BotMovement))]
public class BotScr : MonoBehaviour, IBot
{
    private BotData data;
    private BotMovement movement;

    [Header("-----")]
    [SerializeField]
    int maxHP = 50;
    [SerializeField]
    int minHP = 10;
    [Header("-----")]
    [SerializeField]
    int maxDMG = 8;
    [SerializeField]
    int minDMG = 2;
    [Header("-----")]
    [SerializeField]
    private int speed = 5;

    private void Start()
    {
        data = GetComponent<BotData>();
        movement = GetComponent<BotMovement>();
        Generate();
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
        int num = Random.Range(minHP, maxHP);
        int num2 = Random.Range(minDMG, maxDMG);
        data.health = num;
        data.damage = num2;
        movement.Init(speed);
    }

    public void IncreaseDamage(int mod)
    {
        data.damage += mod;
    }
}
