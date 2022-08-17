using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntentyScr : MonoBehaviour
{
    public virtual int GetHp()
    {
        return 0;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual void ApplyDamage(int damage)
    {
        //
    }
}
