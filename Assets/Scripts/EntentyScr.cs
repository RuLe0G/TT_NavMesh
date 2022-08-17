using UnityEngine;
/// <summary>
/// ������� ����� ��������
/// </summary>
public class EntentyScr : MonoBehaviour
{
    /// <summary>
    /// ������� ���� ������ � ��������
    /// </summary>
    public virtual int GetHp()
    {
        return 0;
    }
    /// <summary>
    /// ����������� �������
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// ��������e ����� ���������
    /// </summary>
    /// <param name="damage">������ �����</param>
    public virtual void ApplyDamage(int damage)
    {
        //
    }
}
