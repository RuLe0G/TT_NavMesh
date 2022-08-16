using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Jobs;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(BotData), typeof(BotMovement))]
public class BotScr : MonoBehaviour, IBot
{
    private BotData data;
    private BotMovement movement;

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
        FindTarg();
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
        if (targ.GetHp() <= data.damage)
        {
            data.score++;
            ui.onScoreChange.Invoke();
        }
        targ.ApplyDamage(data.damage);
    }

    public void Attach(Transform targ)
    {        
        movement.MoveToTarg();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void FindTarg()
    {
        var targ = movement.MarkClosedTarget();
        if (targ != null)
        {        
            movement.SetTaget(targ);
            Attach(movement.target);
        }
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
