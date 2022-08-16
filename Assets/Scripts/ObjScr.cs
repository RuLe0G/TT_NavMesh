using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjData))]
public class ObjScr : MonoBehaviour, IObj
{
    private ObjData data;
    private UIObj ui;

    private void Start()
    {
        ui = GetComponent<UIObj>();
        data = GetComponent<ObjData>();
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

    public void Die()
    {        
        Destroy(gameObject);
    }
    public int GetHp()
    {
        return data.health;
    }
}
