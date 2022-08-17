using UnityEngine;
/// <summary>
/// ����� ���������� ����
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
    /// �������� ���� (������ ��� ������)
    /// </summary>
    public float movSpeed => _movSpeed;
    /// <summary>
    /// ���� ���� {get; set}
    /// </summary>
    public int damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    /// <summary>
    /// ���� ���� {get; set}
    /// </summary>
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }
}
