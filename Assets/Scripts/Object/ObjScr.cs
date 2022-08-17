using UnityEngine;
/// <summary>
/// Класс логики объекта
/// </summary>
[RequireComponent(typeof(ObjData))]
public class ObjScr : EntentyScr, IObj
{
    private ObjData data;
    private UIObj ui;

    private void Start()
    {
        ui = GetComponent<UIObj>();
        data = GetComponent<ObjData>();
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
    public override int GetHp()
    {
        return data.health;
    }
}
