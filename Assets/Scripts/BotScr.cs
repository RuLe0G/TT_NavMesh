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

    private UIBot ui;

    private void Start()
    {
        data = GetComponent<BotData>();
        movement = GetComponent<BotMovement>();
        ui = GetComponent<UIBot>();
        Generate();
    }

    public void ApplyDamage(int damage)
    {
        data.health -= damage;
        ui.onHpChange.Invoke();

        if (data.health <= 0)
        {
            Die();
        }
    }

    public void AttackTarg(ObjScr targ)
    {
        if (targ.GetHp() >= data.damage)
        {
            targ.ApplyDamage(data.damage);
        }
        else
        {
            targ.ApplyDamage(data.damage);
            data.score++;
            ui.onScoreChange.Invoke();
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
