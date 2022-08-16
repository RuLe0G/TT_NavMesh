using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BotData : ObjData
{    
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _movSpeed;
    [SerializeField]
    private int _score;
    public float movSpeed => _movSpeed;

    public int damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }
}
