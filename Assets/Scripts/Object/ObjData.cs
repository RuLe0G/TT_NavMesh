using UnityEngine;
/// <summary>
/// Класс параметров объекта
/// </summary>
public class ObjData : MonoBehaviour
{
    [SerializeField]
    private int _health;
    /// <summary>
    /// Очки здоровья объекта
    /// </summary>
    public int health
    {
        get { return _health; }
        set { _health = value; }
    }
}
