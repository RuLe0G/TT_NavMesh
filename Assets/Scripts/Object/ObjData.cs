using UnityEngine;
/// <summary>
/// ����� ���������� �������
/// </summary>
public class ObjData : MonoBehaviour
{
    [SerializeField]
    private int _health;
    /// <summary>
    /// ���� �������� �������
    /// </summary>
    public int health
    {
        get { return _health; }
        set { _health = value; }
    }
}
