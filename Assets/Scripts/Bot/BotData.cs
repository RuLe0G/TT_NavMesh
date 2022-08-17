using UnityEngine;
/// <summary>
/// Класс параметров бота
/// </summary>
public class BotData : ObjData
{    
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _movSpeed;
    [SerializeField]
    private int _score;
    /// <summary>
    /// Скорость бота (только для чтения)
    /// </summary>
    public float movSpeed => _movSpeed;
    /// <summary>
    /// Урон бота {get; set}
    /// </summary>
    public int damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    /// <summary>
    /// Счет бота {get; set}
    /// </summary>
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }
}
