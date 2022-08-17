using UnityEngine;
/// <summary>
/// Базовый класс сущности
/// </summary>
public class EntentyScr : MonoBehaviour
{
    /// <summary>
    /// Вернуть очки жизней у сущности
    /// </summary>
    public virtual int GetHp()
    {
        return 0;
    }
    /// <summary>
    /// Уничтожение суности
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// Получениe урона сущностью
    /// </summary>
    /// <param name="damage">Едениц урона</param>
    public virtual void ApplyDamage(int damage)
    {
        //
    }
}
