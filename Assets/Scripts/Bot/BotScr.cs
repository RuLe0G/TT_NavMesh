using System.Collections;
using UnityEngine;
/// <summary>
/// Класс логики бота
/// </summary>
[RequireComponent(typeof(BotData), typeof(BotMovement))]
public class BotScr : EntentyScr, IBot
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

    private bool isAtck = false;

    private void Start()
    {
        data = GetComponent<BotData>();
        movement = GetComponent<BotMovement>();
        ui = GetComponent<UIBot>();
        Generate();
        FindTarg();
    }

    public override void ApplyDamage(int damage)
    {
        if (data != null)
        {
            data.health -= damage;
            ui.onHpChange.Invoke();

            if (data.health <= 0)
            {
                Die();
            }
        }
    }
    /// <summary>
    /// Атака цели, пока она жива
    /// </summary>
    /// <param name="targ"></param>
    public void AttackTarg(EntentyScr targ)
    {
        if (targ != null)
        {
            isAtck = true;
            StartCoroutine(AtkUnitlDie(targ));
        }
        else
        {
            StopCoroutine(AtkUnitlDie(targ));

        }
    }
    /// <summary>
    /// Запускает движение в сторону цели
    /// </summary>
    public void Attach()
    {
        movement.MoveToTarg();
    }

    public override void Die()
    {
        StopAllCoroutines();
        movement.SetTaget(null);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (movement.GetTarget() == null)
        {
            FindTarg();
        }
        else if (movement.isReached)
        {
            if (!isAtck)
            {
                AttackTarg(movement.GetTarget().GetComponent<EntentyScr>());
            }
        }
    }
    /// <summary>
    /// Объект ищет цель и устанавливает в качестве метки.
    /// </summary>
    public void FindTarg()
    {
        var targ = movement.MarkClosedTarget();

        if (targ != null)
        {
            movement.SetTaget(targ);
            Attach();
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

    private IEnumerator AtkUnitlDie(EntentyScr targ)
    {
        if (targ != null)
        {

            while (movement.GetTarget() != null)
            {
                yield return wait(1f);
                if (targ.GetHp() <= data.damage & targ != null & movement.GetTarget() != null)
                {
                    isAtck = false;
                    data.score++;
                    ui.onScoreChange.Invoke();
                    movement.isReached = false;
                    this.IncreaseDamage(2);
                }
                targ.ApplyDamage(data.damage);

            }
            movement.SetTaget(null);
            targ = null;
        }

        yield return null;
    }

    private IEnumerator wait(float waitTime)
    {
        float counter = 0;

        while (counter < waitTime)
        {
            counter += Time.deltaTime;

            yield return null;
        }
    }
    public override int GetHp()
    {
        return data.health;
    }
}
